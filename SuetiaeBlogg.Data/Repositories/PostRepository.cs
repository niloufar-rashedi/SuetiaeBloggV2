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

        public Task<IEnumerable<Post>> GetAllWithCategoryAsync()
        {
            throw new NotImplementedException();
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
