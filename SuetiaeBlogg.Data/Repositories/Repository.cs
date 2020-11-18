using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Repositories;

namespace SuetiaeBlogg.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected SuetiaeBloggDbContext Context { get; set; }
        public Repository(SuetiaeBloggDbContext context)
        {
            this.Context = context;
        }
        public IQueryable<T> FindAll()
        {
            return this.Context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.Context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.Context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
        }
    }


}
}
