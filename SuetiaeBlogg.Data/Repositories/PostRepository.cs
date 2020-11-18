using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;

namespace SuetiaeBlogg.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private SuetiaeBloggDbContext _context;
        public PostRepository(SuetiaeBloggDbContext context) 
        {
            this._context = context;
        }

    
        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts
                                 .Include(a => a.Author)
                                 .Include(t => t.Comments)
                                 .Include(c => c.PostCategories)
                                 .ThenInclude(Postcategories => Postcategories.Category)
                                 .Include(t => t.PostTags)
                                 .ThenInclude(PostTags => PostTags.Tag)
                                 .AsNoTracking()
                                 .ToListAsync();

        }
        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _context.Posts
                                    .Where(d => d.PostId == postId)
                                    .Include(a => a.Author)
                                    .Include(c => c.PostCategories)
                                    .ThenInclude(Postcategories => Postcategories.Category)
                                    .Include(t => t.PostTags)
                                    .ThenInclude(PostTags => PostTags.Tag)
                                    .Include(t => t.Comments)
                                    .FirstOrDefaultAsync();
        }
        public async Task DeletePost(int postId)
        {
            var post = GetPostByIdAsync(postId);
            _context.Remove(post);
            await _context.SaveChangesAsync();
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
