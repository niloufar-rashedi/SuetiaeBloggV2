using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;

        public PostService(SuetiaeBloggDbContext context, IMapper mapper, ICategoryService categoryService, IAuthorService authorService)
        {
            this._context = context;
            this._mapper = mapper;
            this._categoryService = categoryService;
            this._authorService = authorService;
        }
        public async Task<ServiceResponse<IEnumerable<GetPostDto>>> GetPosts()
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
        public  async Task<ServiceResponse<GetPostDto>> FindPostById(int postId)
        {
            ServiceResponse<GetPostDto> response = new ServiceResponse<GetPostDto>();
            try
            {
                var post = await _context.Posts
                                    .Where(d => d.PostId == postId)
                                    .Include(a => a.Author)
                                    .Include(c => c.PostCategories)
                                    .ThenInclude(Postcategories => Postcategories.Category)
                                    .Include(t => t.PostTags)
                                    .ThenInclude(PostTags => PostTags.Tag)
                                    .Include(t => t.Comments)
                                    .FirstOrDefaultAsync();
                                     


                if (post == null)
                {
                    response.Message = "Post not found";
                }
                else
                    response.Data = _mapper.Map<GetPostDto>(post);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<Post>> CreatePost(AddPostDto newPost)

        {
            ServiceResponse<Post> response = new ServiceResponse<Post>();
            try
            {
                var author = await _authorService.FindAuthorById(newPost.AuthorId);
                var post = new Post()
                {
                    Author = author,
                    Title = newPost.Title,
                    Summary = newPost.Summary,
                    Body = newPost.Body,
                    LastModified = newPost.LastModified
                };
                _context.Posts.Add(post);
                //now check if the new post as a category specified
                //var categoryName = newPost.Categories.FirstOrDefault().Name;
                //if (!string.IsNullOrEmpty(categoryName))
                //{
                //    //finds the category object that corresponds to the category name received
                //    //just one category is added from the frontend
                //    var query = await _categoryService.FindCategoryByName(categoryName);
                //    if (!query.Success)
                //    {
                //        response.Message = "There has been a problem retrieving the category";
                //    }
                //    var category = query.Data.FirstOrDefault();
                //    var postCategory = new PostCategories
                //    {
                //        Post = post,
                //        Category = category
                //    };
                //    _context.PostCategories.Add(postCategory);
                //}
                //else
                //{
                //    //assign the default category as General that is the category with Id 1
                //    var category = await _context.Categories.Where(c => c.CategoryId == 1)
                //                            .ToListAsync();
                //    var postCategory = new PostCategories
                //    {
                //        Post = post,
                //        Category = category.FirstOrDefault()
                //    };
                //    _context.PostCategories.Add(postCategory);
                //}
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<Post>(newPost);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ServiceResponse<Task> UpdatePost(Post postToBeUpdated, Post post)
        {
            throw new NotImplementedException();
        }
        public ServiceResponse<Task> DeletePost(Post post)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<GetPostDto>> FindPostByDate(DateTime pubdate)
        {
            throw new NotImplementedException();
        }

        ServiceResponse<Task> IPostService.DeletePost(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
