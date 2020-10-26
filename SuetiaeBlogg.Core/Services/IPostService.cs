using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Models.Posts;

namespace SuetiaeBlogg.Core.Services
{
    public interface IPostService
    {
        //add category to existing post

        Task<ServiceResponse<IEnumerable<GetPostDto>>> GetAllComplete();
        Task<ServiceResponse<IEnumerable<GetPostHeadlineDto>>> GetAllHeadline();
        Task<ServiceResponse<IEnumerable<GetPostDto>>> GetPostById(int Id);
        public Task<ServiceResponse<Post>> CreatePost(Post newPost);
        public ServiceResponse<Task> UpdatePost(Post postToBeUpdated, Post post);
        public ServiceResponse<Task> DeletePost(Post post);
        public Task<ServiceResponse<Post>> FindPostsByAuthorId(int authorId);
        public Task<ServiceResponse<Post>> FindPostsByTagId(int tagId);



    }
}
