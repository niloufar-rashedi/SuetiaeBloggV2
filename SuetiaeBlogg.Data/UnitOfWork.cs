﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Repositories;
using SuetiaeBlogg.Data.Repositories;

namespace SuetiaeBlogg.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuetiaeBloggDbContext _context;
        private PostRepository _postRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(SuetiaeBloggDbContext context)
        {
            this._context = context;
        }

        public IPostRepository Posts => _postRepository = _postRepository ?? new PostRepository(_context);

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);



        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}