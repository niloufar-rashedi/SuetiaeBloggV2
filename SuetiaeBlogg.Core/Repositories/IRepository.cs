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
        IEnumerable<T> FindAll();
        T GetByID(object id);
        void Insert(T entity);
        void Delete(object id);
        void Update(T entityToUpdate);

        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
