using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Repositories;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;

namespace SuetiaeBlogg.Services.Services
{
    public class CategoryService : ICategoryService
    {
        
        //private readonly IUnitOfWork _unitOfWork;
        private readonly SuetiaeBloggDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(SuetiaeBloggDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<GetPostDto>>> FindPostsByCategoryId(int categoryId)
        {
            ServiceResponse<IEnumerable<GetPostDto>> response = new ServiceResponse<IEnumerable<GetPostDto>>();
            try
            {
                var postIds = await _context.PostCategories
                                    .Where(c => c.CategoryId == categoryId)
                                    .Select(x => x.PostId)
                                    .Distinct()
                                    .ToListAsync();
                var posts = await _context.Posts
                                .Where(x => postIds.Contains(x.PostId))
                                .Include(a => a.Author)
                                .Include(c => c.PostCategories)
                                .ThenInclude(Postcategories => Postcategories.Category)
                                .Include(t => t.PostTags)
                                .ThenInclude(PostTags => PostTags.Tag)
                                .Include(t => t.Comments)
                                .ToListAsync();

                if (posts.Count() == 0)
                {
                    response.Message = "No posts found in this category";
                }
                else
                    response.Data = _mapper.Map<IEnumerable<GetPostDto>>(posts);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetCategories()
        {
            ServiceResponse<IEnumerable<GetCategoryDto>> response = new ServiceResponse<IEnumerable<GetCategoryDto>>();
            try
            {
                var categories = await _context.Categories

                                    .ToListAsync();


                response.Data = _mapper.Map<IEnumerable<GetCategoryDto>>(categories);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public Task<ServiceResponse<GetPostDto>> AddCategoryToAPost(AddPostCategoryDto newPostCategory)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<GetPostDto>> AddPostCategory(AddPostCategoryDto newPostCategory)
        {
            ServiceResponse<GetPostDto> response = new ServiceResponse<GetPostDto>();
            try
            {
                Post post = await _context.Posts
                                    .FirstOrDefaultAsync(c => c.PostId == newPostCategory.PostId);
                if (post == null)
                {
                    response.Success = false;
                    response.Message = "Post not found.";
                    return response;
                }
                Category category = await _context.Categories
                                    .FirstOrDefaultAsync(s => s.CategoryId == newPostCategory.CategoryId);
                if (category == null)
                {
                    response.Success = false;
                    response.Message = "Category not found.";
                    return response;
                }
                PostCategories postCategory = new PostCategories
                {
                    Post = post,
                    Category = category
                };

                await _context.PostCategories.AddAsync(postCategory);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetPostDto>(post);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public Task<Category> CreateCategory(Category newCategory)
        {
            throw new NotImplementedException();
        }
        public Task UpdateCategory(Category categoryToBeUpdated, Category category)
        {
            throw new NotImplementedException();
        }
        public Task DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}

