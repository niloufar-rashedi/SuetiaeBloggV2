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
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private SuetiaeBloggDbContext _context;
        public PostRepository(SuetiaeBloggDbContext context) : base(context)
        {
            this._context = context;
        }

    
        public async Task<IEnumerable<Post>> GetAllWithCategoryAsync()
        {
            return await _context.Posts
                .Include(p => p.PostCategories)
                .ThenInclude(e => e.Category)
                .ToListAsync();
                    
        }
        public Task<IEnumerable<Post>> GetAllWithCategoryByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetWithCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
