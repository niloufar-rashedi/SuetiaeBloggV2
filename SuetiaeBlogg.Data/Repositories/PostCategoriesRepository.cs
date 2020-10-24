using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;

namespace SuetiaeBlogg.Data.Repositories
{
    public class PostCategoriesRepository : Repository<PostCategories>, IPostCategoriesRepository
    {
        public PostCategoriesRepository(SuetiaeBloggDbContext context)
            : base(context)
        { }
        public Task<IEnumerable<PostCategories>> GetAllWithCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostCategories>> GetAllWithCategoryByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<PostCategories> GetWithCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
