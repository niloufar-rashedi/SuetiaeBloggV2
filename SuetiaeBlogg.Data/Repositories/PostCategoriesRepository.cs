using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;

namespace SuetiaeBlogg.Data.Repositories
{
    public class PostCategoriesRepository : Repository<PostCategories>, IPostCategoriesRepository
    {
        private SuetiaeBloggDbContext _context;
        public PostCategoriesRepository(SuetiaeBloggDbContext context)
            : base(context)
        {
            this._context = context;
        }
        
        public Task<IEnumerable<PostCategories>> GetAllWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostCategories>> GetAllWithCategoryByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<PostCategories> GetPostCategoryByCategoryNameAsync(string categoryName)
        {
            var category = await _context.Categories
                                         .Where(c => c.Name == categoryName)
                                         .ToListAsync();

            var postcategory = await _context.PostCategories
                                         .Where(c => c.CategoryId == category.FirstOrDefault().CategoryId)
                                         .ToListAsync();

            return postcategory.FirstOrDefault();
        }

        public Task<PostCategories> GetWithCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
