﻿using AutoMapper;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Data;
using SuetiaeBlogg.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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

        public Author Authenticate(string username, string password)
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

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors;
        }

        public Author GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public Author Create(Author author, string password)
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

        public void Update(Author userParam, string password = null)
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
    }
}
