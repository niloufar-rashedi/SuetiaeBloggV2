using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Models.Posts;

namespace SuetiaeBlogg.Core.Services
{
    public interface IPostCategoryService
    {
        //add category to existing post
        Task<ServiceResponse<GetPostDto>> AddPostCategory(AddPostCategoryDto newPostCategory);
        Task<ServiceResponse<IEnumerable<GetPostDto>>> GetAllWithCategories();
    }
}
