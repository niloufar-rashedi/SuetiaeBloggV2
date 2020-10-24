using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.Core.Services
{
    public interface IPostService
    {
        Task<ServiceResponse<IEnumerable<Post>>> GetAllWithCategories();
        Task<ServiceResponse<Post>> GetPostById(int id);
        Task<ServiceResponse<IEnumerable<Post>>> GetPostsByCategoryId(int categoryId);
        Task<ServiceResponse<Post>> CreatePost(Post newPost);
        ServiceResponse<Task> UpdatePost(Post postToBeUpdated, Post post);
        ServiceResponse<Task> DeletePost(Post post);
    }
}
