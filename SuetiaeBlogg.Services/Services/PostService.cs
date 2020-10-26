using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.Comments;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Repositories;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;

namespace SuetiaeBlogg.Services.Services
{
    public class PostService : IPostService
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly SuetiaeBloggDbContext _context;
        private readonly IMapper _mapper;


        public PostService(SuetiaeBloggDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<GetPostDto>>> GetAllComplete()
        {
            ServiceResponse<IEnumerable<GetPostDto>> response = new ServiceResponse<IEnumerable<GetPostDto>>();
            try
            {
                var posts = await _context.Posts
                                    .Include(a => a.Author)
                                    .Include(c => c.PostCategories)
                                    .ThenInclude(Postcategories => Postcategories.Category)
                                    .Include(t => t.PostTags)
                                    .ThenInclude(PostTags => PostTags.Tag)
                                    .Include(t => t.Comments)
                                    .AsNoTracking()
                                    .ToListAsync();


                response.Data = _mapper.Map<IEnumerable<GetPostDto>>(posts);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<IEnumerable<GetPostHeadlineDto>>> GetAllHeadline()
        {
            ServiceResponse<IEnumerable<GetPostHeadlineDto>> response = new ServiceResponse<IEnumerable<GetPostHeadlineDto>>();
            try
            {
                var posts = await _context.Posts
                                    .Include(p => p.Author)
                                    .Include(c => c.PostCategories)
                                    .ThenInclude(Postcategories => Postcategories.Category)
                                    .Include(t => t.PostTags)
                                    .ThenInclude(PostTags => PostTags.Tag)
                                    .Select(g => new GetCommentsCountDto()
                                    {
                                        Post = g,
                                        CommentsCount = g.Comments.Count(),
                                    })
                                    .AsNoTracking()
                                    .ToListAsync();




                response.Data = _mapper.Map<IEnumerable<GetPostHeadlineDto>>(posts);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<IEnumerable<GetPostDto>>> GetPostById(int postId)
        {
            ServiceResponse<IEnumerable<GetPostDto>> response = new ServiceResponse<IEnumerable<GetPostDto>>();
            try
            {
                var posts = await _context.Posts
                                    .Include(a => a.Author)
                                    .Include(c => c.PostCategories)
                                    .ThenInclude(Postcategories => Postcategories.Category)
                                    .Include(t => t.PostTags)
                                    .ThenInclude(PostTags => PostTags.Tag)
                                    .Include(t => t.Comments)
                                    .Select(d => d.PostId == postId)
                                    .FirstOrDefaultAsync();



                response.Data = _mapper.Map<IEnumerable<GetPostDto>>(posts);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public Task<ServiceResponse<Post>> CreatePost(Post newPost)
        {
            throw new NotImplementedException();
        }
        public ServiceResponse<Task> UpdatePost(Post postToBeUpdated, Post post)
        {
            throw new NotImplementedException();
        }
        public ServiceResponse<Task> DeletePost(Post post)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<Post>> FindPostsByAuthorId(int authorId)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<Post>> FindPostsByTagId(int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
