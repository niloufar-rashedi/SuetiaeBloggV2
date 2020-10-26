using System;
using System.Collections.Generic;
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
        public async Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetAllCategories()
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
        public Task<ServiceResponse<IEnumerable<Post>>> GetPostsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Category>> GetAllWithPosts()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Category>> GetCategoriesByPostId(int postId)
        {
            throw new NotImplementedException();
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
        public Task DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<IEnumerable<Post>>> FindPostsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }
        public Task<Category> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateCategory(Category categoryToBeUpdated, Category category)
        {
            throw new NotImplementedException();
        }
    }
}

