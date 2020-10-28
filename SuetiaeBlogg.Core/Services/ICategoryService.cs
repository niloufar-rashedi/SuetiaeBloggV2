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
        public Task<ServiceResponse<GetPostDto>> AddCategoryToAPost(AddPostCategoryDto newPostCategory);
        public Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetCategories();
        public Task<ServiceResponse<IEnumerable<GetPostDto>>> FindPostsByCategoryId(int categoryId);
        public Task<Category> CreateCategory(Category newCategory);
        public Task UpdateCategory(Category categoryToBeUpdated, Category category);
        public Task DeleteCategory(Category category);
    }
}
