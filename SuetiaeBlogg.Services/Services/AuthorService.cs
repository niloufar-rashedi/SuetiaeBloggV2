using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Authors;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;

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
                                .Include(c => c.PostCategories)
                                .ThenInclude(Postcategories => Postcategories.Category)
                                .Include(t => t.PostTags)
                                .ThenInclude(PostTags => PostTags.Tag)
                                .Include(t => t.Comments)
                                .ToListAsync();

                if (posts.Count()==0)
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
    }
}
