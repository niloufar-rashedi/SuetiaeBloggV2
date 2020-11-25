using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.Comments;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Models.Posts;

namespace SuetiaeBlogg.Core.Services
{
    public interface IPostService
    {
        public Task<ServiceResponse<IEnumerable<GetPostDto>>> GetPosts();
        public Task<ServiceResponse<GetPostDto>> FindPostById(int Id);
        public Task<ServiceResponse<Post>> CreatePost(AddPostDto newPost);
        public Task<ServiceResponse<Post>> UpdatePost(int postId, AddPostDto postToBeUpdated);
        public Task<ServiceResponse<Task>> CreateComment(int postId, AddCommentDto newComment);
        public Task<ServiceResponse<Task>> DeletePost(int Id);

        //Added methods to ease testing, i.e. avoiding Dto
        public IEnumerable<Author> GetPostsWithoutDto();
       
    }
}
