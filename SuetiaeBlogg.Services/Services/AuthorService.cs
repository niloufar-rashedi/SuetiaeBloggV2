using AutoMapper;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Data;
using SuetiaeBlogg.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models.Authors;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Services;

namespace SuetiaeBlogg.Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly SuetiaeBloggDbContext _context;
        private readonly IMapper _mapper;
        public AuthorService(SuetiaeBloggDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<GetPostDto>>> FindPostsByAuthorId(int authorId)
        {
            ServiceResponse<IEnumerable<GetPostDto>> response = new ServiceResponse<IEnumerable<GetPostDto>>();
            try
            {
                var posts = await _context.Posts
                                .Where(x => x.Author.AuthorId == authorId)
                                .Include(a => a.Author)
                                .Include(c => c.PostCategories)
                                .ThenInclude(Postcategories => Postcategories.Category)
                                .Include(t => t.PostTags)
                                .ThenInclude(PostTags => PostTags.Tag)
                                .Include(t => t.Comments)
                                .ToListAsync();

                if (posts.Count() == 0)
                {
                    response.Message = "No posts found by this author";
                }
                else
                    response.Data = _mapper.Map<IEnumerable<GetPostDto>>(posts);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return (response);
        }

        public async Task<ServiceResponse<IEnumerable<GetAuthorDto>>> GetAllAuthors()
        {
            {
                ServiceResponse<IEnumerable<GetAuthorDto>> response = new ServiceResponse<IEnumerable<GetAuthorDto>>();
                try
                {
                    var authors = await _context.Authors
                                             .ToListAsync();


                    response.Data = _mapper.Map<IEnumerable<GetAuthorDto>>(authors);
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                }

                return response;
            }
        }
        Author IAuthorService.Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var author = _context.Authors.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (author == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, author.PasswordHash, author.PasswordSalt))
                return null;

            // authentication successful
            return author;
        }

        Author IAuthorService.Create(Author author, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Authors.Any(x => x.Username == author.Username))
                throw new AppException("Username '" + author.Username + "' is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            author.PasswordHash = passwordHash;
            author.PasswordSalt = passwordSalt;

            _context.Authors.Add(author);
            _context.SaveChanges();

            return author;
        }

         void IAuthorService.Update(Author userParam, string password)
        {
            var author = _context.Authors.Find(userParam.AuthorId);

            if (author == null)
                throw new AppException("Author not found");

            if (userParam.Username != author.Username)
            {
                // username has changed so check if the new username is already taken
                if (_context.Authors.Any(x => x.Username == userParam.Username))
                    throw new AppException("Author " + userParam.Username + " is already writing for Suetiae! ");
            }

            // update user properties
            author.FirstName = userParam.FirstName;
            author.LastName = userParam.LastName;
            author.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                author.PasswordHash = passwordHash;
                author.PasswordSalt = passwordSalt;
            }

            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        //Author IAuthorService.Authenticate(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}

        //Author IAuthorService.Create(Author author, string password)
        //{
        //    throw new NotImplementedException();
        //}

        //void IAuthorService.Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerable<Author> IAuthorService.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        Author IAuthorService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> FindAuthorById(int authorId)
        {
            try
            {
                var author = await _context.Authors
                                    .Where(d => d.AuthorId == authorId)
                                    .FirstOrDefaultAsync();
                return author;



                
               
            }
            catch
            {
                throw new ArgumentNullException("Author not found");
                
            }
            
            
        }

        //void IAuthorService.Update(Author userParam, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

