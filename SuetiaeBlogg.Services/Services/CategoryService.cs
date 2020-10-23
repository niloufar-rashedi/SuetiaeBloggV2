using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;
using SuetiaeBlogg.Core.Services;

namespace SuetiaeBlogg.Services.Services
{
    public class CategoryService : ICategoryService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> CreateCategory(IEnumerable<Category> newCategory)
        {
            await _unitOfWork.Categories
                .AddAsync(newCategory);

            return newCategory;
        }

        public Task<Category> CreateCategory(Category newCategory)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCategory(Category category)
        {
            _unitOfWork.Categories.Remove(category);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public Task<IEnumerable<Category>> GetAllWithPosts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetCategoriesByPostId(int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task UpdateCategory(Category categoryToBeUpdated, Category category)
        {
            categoryToBeUpdated.Name = category.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}

