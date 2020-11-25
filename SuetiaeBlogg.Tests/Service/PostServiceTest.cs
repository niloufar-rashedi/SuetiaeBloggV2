using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NSubstitute;
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
    public class PostServiceTest
    {
        [Fact]
        public async void GetPosts_Should_Return_Posts()
        {
            var _categoryServiceTest = new Mock<ICategoryService>().Object;
            var _authorServiceTest = new Mock<IAuthorService>().Object;
            var _mapperTest = new Mock<IMapper>().Object;

            var mockPosts = new List<Post>()
        {
            new Post {PostId = 1, Title = "First post", Summary = "First Summary", LastModified = DateTime.Now, Comments = new List<Comment>()},
            new Post {PostId = 2, Title = "Second post", Summary = "Second Summary", LastModified = DateTime.Now, Comments = new List<Comment>()}
        }.AsQueryable();

            var mockSet = Substitute.For<DbSet<Post>, IQueryable<Post>>();

            // setup all IQueryable methods using what you have from "data"
            ((IQueryable<Post>)mockSet).Provider.Returns(mockPosts.Provider);
            ((IQueryable<Post>)mockSet).Expression.Returns(mockPosts.Expression);
            ((IQueryable<Post>)mockSet).ElementType.Returns(mockPosts.ElementType);
            ((IQueryable<Post>)mockSet).GetEnumerator().Returns(mockPosts.GetEnumerator());
            var dbContextMock = Substitute.For<SuetiaeBloggDbContext>();
            dbContextMock.Posts.Returns(mockSet);

            // Act
            var posts = new PostService(dbContextMock, _mapperTest, _categoryServiceTest, _authorServiceTest);
            var data = await posts.FindPostsAsync();

            // Assert
            Assert.Equal("First post", data.FirstOrDefault().Title);
        }
    }
}
