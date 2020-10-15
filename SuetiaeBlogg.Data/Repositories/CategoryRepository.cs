using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;

namespace SuetiaeBlogg.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(SuetiaeBloggDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Category>> GetAllWithPostsAsync()
        {
            return await SuetiaeBloggDbContext.Categories
                .Include(a => a.Posts)
                .ToListAsync();
        }

        public Task<Category> GetWithPostssByIdAsync(int id)
        {
            return SuetiaeBloggDbContext.Categories
               .Include(a => a.Posts)
               .SingleOrDefaultAsync(a => a.Id == id);
        }
        private SuetiaeBloggDbContext SuetiaeBloggDbContext
        {
            get { return Context as SuetiaeBloggDbContext; }
        }
    }
}
