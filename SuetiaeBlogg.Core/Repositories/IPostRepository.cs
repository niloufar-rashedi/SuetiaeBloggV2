using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.Core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllWithCategoryAsync();
        Task<Post> GetWithCategoryByIdAsync(Guid id);
        Task<IEnumerable<Post>> GetAllWithCategoryByCategoryIdAsync(Guid categoryId);
    }
}
