using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using GenFu;
using SuetiaeBlogg.API.Controllers;
using SuetiaeBlogg.API.Mapping;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;
using SuetiaeBlogg.Services.Services;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SuetiaeBlogg.Tests.Service
{
    public class PostServiceTest
    {
        private IEnumerable<Post> GetFakeData()
        {
            var i = 1;
            var posts = A.ListOf<Post>(3);
            posts.ForEach(x => x.PostId = i++);
            return posts.Select(_ => _);
        }
        [Fact]
        public void GetPersonsTest()
        {
            // arrange
            var service = new Mock<IPostService>();

            var posts = GetFakeData();
            service.Setup(x => x.GetPostsWithoutDto()).Returns((Delegate)posts);

            var controller = new BlogPostsController(service.Object);

            // Act
            var results = controller.GetGetAllPostsWithoutDto();

            var count = results.Count();

            // Assert
            Assert.Equal(count, 3);
        }

        private Mock<SuetiaeBloggDbContext> CreateDbContext()
        {
            var posts = GetFakeData().AsQueryable();

            var dbSet = new Mock<DbSet<Post>>();
            dbSet.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(posts.Provider);
            dbSet.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(posts.Expression);
            dbSet.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(posts.ElementType);
            dbSet.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(posts.GetEnumerator());

            var context = new Mock<SuetiaeBloggDbContext>();
            context.Setup(c => c.Posts).Returns(dbSet.Object);
            return context;
        }
        [Fact]
        public void FindPostTest()
        {
            // arrange
            var context = CreateDbContext();

            var service = new PostService(context.Object);

            // act
            //var post = service.FindPostById(1);

            // assert
            //Assert.Equal(1, post.Id);
        }


        //    private IUnitOfWork _mockUOW;



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
    }
}
