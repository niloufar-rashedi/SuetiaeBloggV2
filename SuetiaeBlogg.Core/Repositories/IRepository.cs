using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SuetiaeBlogg.Core.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get(string includeProperties, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        T GetByID(object id);
        void Insert(T entity);
        void Delete(T entityToDelete);
        void Delete(object id);
        void Update(T entityToUpdate);
        
    }
}
