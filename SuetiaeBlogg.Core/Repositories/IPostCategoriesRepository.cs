using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.Core.Repositories
{
    public interface IPostCategoriesRepository
    {
        Task<IEnumerable<PostCategories>> GetAllWithCategoryAsync();
        Task<PostCategories> GetWithCategoryByIdAsync(int id);
        Task<IEnumerable<PostCategories>> GetAllWithCategoryByCategoryIdAsync(int categoryId);
        Task<PostCategories> GetPostCategoryByCategoryNameAsync(string categoryName);
    }
}
