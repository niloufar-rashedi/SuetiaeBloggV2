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
        public PostRepository(SuetiaeBloggDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Post>> GetAllWithCategoryAsync()
        {
            return await SuetiaeBloggDbContext.Posts
                .Include(m => m.Categories)
                .ToListAsync();
        }

        public async Task<Post> GetWithCategoryByIdAsync(Guid id)
        {
            return await SuetiaeBloggDbContext.Posts
                .Include(m => m.Categories)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Post>> GetAllWithCategoryByCategoryIdAsync(Guid categoryId)
        {
            throw new NotImplementedException(); 
        //    return await SuetiaeBloggDbContext.Posts
        //        .Include(m => m.Categories)
        //        .Where(m => m.Categories.Id == categoryId)
        //        .ToListAsync();
        }

        private SuetiaeBloggDbContext SuetiaeBloggDbContext
        {
            get { return Context as SuetiaeBloggDbContext; }
        }

    }
}
