using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.Core.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllWithcategory();
        Task<Post> GetPostById(int id);
        Task<IEnumerable<Post>> GetPostsByCategoryId(int categoryId);
        Task<Post> CreatePost(Post newPost);
        Task UpdatePost(Post postToBeUpdated, Post post);
        Task DeletePost(Post post);
    }
}
