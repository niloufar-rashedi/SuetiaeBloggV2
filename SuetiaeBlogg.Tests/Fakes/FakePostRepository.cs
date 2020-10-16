using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;

namespace SuetiaeBlogg.Tests.Fakes
{
    public class FakePostRepository : IPostRepository
    {
        public Task AddAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Post> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> Find(Expression<Func<Post, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllWithCategoryByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Post> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetWithCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Post entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Post> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Post> SingleOrDefaultAsync(Expression<Func<Post, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
