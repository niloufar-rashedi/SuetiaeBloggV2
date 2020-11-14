using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(Author entityToDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> Find(Expression<Func<Author, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> Get(string includeProperties, Expression<Func<Author, bool>> filter = null, Func<IQueryable<Author>, IOrderedQueryable<Author>> orderBy = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Author GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Author> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Author entity)
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

        public void Update(Author entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
