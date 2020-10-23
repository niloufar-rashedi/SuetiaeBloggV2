﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.Core.Repositories
{
    public interface IPostCategoriesRepository: IRepository<PostCategories>
    {
        Task<IEnumerable<PostCategories>> GetAllWithCategoryAsync();
        Task<PostCategories> GetWithCategoryByIdAsync(int id);
        Task<IEnumerable<PostCategories>> GetAllWithCategoryByCategoryIdAsync(int categoryId);
    }
}