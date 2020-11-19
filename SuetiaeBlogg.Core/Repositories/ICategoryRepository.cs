using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.Core.Repositories
{
        public interface ICategoryRepository 
        {
            Task<IEnumerable<Category>> GetAllWithPostsAsync();
            Task<Category> GetWithPostssByIdAsync(int id);
        }
    
}
