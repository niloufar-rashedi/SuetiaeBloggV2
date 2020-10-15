﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;

namespace SuetiaeBlogg.Tests.Fakes
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        public Task AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllWithPostsAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetWithPostssByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Category> SingleOrDefaultAsync(Expression<Func<Category, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}