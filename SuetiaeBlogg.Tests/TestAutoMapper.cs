using System;
using System.Collections.Generic;
using AutoMapper;
using SuetiaeBlogg.API.Mapping;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Comments;
using SuetiaeBlogg.Core.Models.Posts;
using Xunit;

namespace SuetiaeBlogg.Tests
{
    public class TestAutoMapper
    {
        [Fact]
        public void AutoMapperConfigIsvalid()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            config.AssertConfigurationIsValid();
            var author = new Author { AuthorId = 1, FirstName = "Anna", LastName = "test", Username = "anna@123.com" };
            var comment = new Comment { CommentId = 1, Author = author, Body = "Comment for testing" };
                    
            var post = new Post
            {
                PostId = 1,
                Author = author,
                Comments = new List<Comment> { comment}
                
            };
            var mapper = config.CreateMapper();
            var commentDto = mapper.Map<Comment, GetCommentDto>(comment);
            var postDto = mapper.Map<GetPostDto>(post);


            Assert.Equal("Anna", commentDto.FirstName);
            //Assert.Equal("Anna", postDto.Comments.FindIndex



        }
    }
}
