using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Models.Posts;

namespace SuetiaeBlogg.Core.Services
{
    public interface ICategoryService
    {
        Task<ServiceResponse<GetPostDto>> AddCategoryToAPost(AddPostCategoryDto newPostCategory);
        Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetAllCategories();
        public Task<ServiceResponse<IEnumerable<GetPostDto>>> FindPostsByCategoryId(int categoryId);
        Task<IEnumerable<Category>> GetAllWithPosts();
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetCategoriesByPostId(int postId);
        Task<Category> CreateCategory(Category newCategory);
        Task UpdateCategory(Category categoryToBeUpdated, Category category);
        Task DeleteCategory(Category category);
    }
}
