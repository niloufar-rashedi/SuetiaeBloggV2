using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;

namespace SuetiaeBlogg.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public Task AddAsync(IEnumerable<Author> entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Author> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> Find(Expression<Func<Author, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Author> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Author entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Author> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Author> SingleOrDefaultAsync(Expression<Func<Author, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
