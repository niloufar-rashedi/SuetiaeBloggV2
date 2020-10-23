using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;

namespace SuetiaeBlogg.Tests.Fakes
{
    public class FakePostCategoriesRepository : IPostCategoriesRepository
    {
        
        public Task AddAsync(IEnumerable<PostCategories> entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<PostCategories> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostCategories> Find(Expression<Func<PostCategories, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostCategories>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostCategories>> GetAllWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostCategories>> GetAllWithCategoryByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<PostCategories> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PostCategories> GetWithCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(PostCategories entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<PostCategories> entities)
        {
            throw new NotImplementedException();
        }

        public Task<PostCategories> SingleOrDefaultAsync(Expression<Func<PostCategories, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
