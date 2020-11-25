using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SuetiaeBlogg.API.Controllers;
using SuetiaeBlogg.API.Mapping;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Comments;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;
using SuetiaeBlogg.Services.Services;
using Xunit;

namespace SuetiaeBlogg.Tests.Service
{
    public class FakePostServiceTest : IPostService
    {
         //    [Fact]
        //    public  Task GetAllWithCategoriesShouldReturnsAllPostsWithCategories()
        //    {
        //        // Arrange

        //        var mockPosts = new List<Post>() {
        //            new Post() { Title = "this is the first post with complete model", Body = "Write something here!" },
        //            new Post() { Title = "this is the second post with complete model", Body = "Good news??" }
        //        };

        //        var mockCategories = new List<Category>(){
        //            new Category { Name = "General" },
        //            new Category { Name = "Event" }
        //        };

        //        var mockPostCategories = new List<PostCategories>() {
        //            new PostCategories { Post = mockPosts[0], Category = mockCategories[0] },
        //            new PostCategories { Post = mockPosts[1], Category = mockCategories[1] }
        //        };


        //        //var sut = new PostService();


        //    //Act

        //        // Assert
        //       // Assert.NotNull(result);

        //    }
        public Task<ServiceResponse<Task>> CreateComment(int postId, AddCommentDto newComment)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Post>> CreatePost(AddPostDto newPost)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Task>> DeletePost(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetPostDto>> FindPostById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<GetPostDto>>> GetPosts()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Post>> UpdatePost(int postId, AddPostDto postToBeUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
