using GenFu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SuetiaeBlogg.API.Controllers;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Authors;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SuetiaeBlogg.Tests
{
    public class AuthorControllerTests : IClassFixture<TestFixture<Startup>>
    {
        //private readonly object _authorInstance;
        //private GetAuthorDto authorInstance;
        //private Author author;

        //private object GetFakeData( /*GetAuthorDto _authorInstance*/)
        //{
        //    //_authorInstance = authorInstance;
        //    var i = 7;
        //    var authorsToSeed = A.ListOf<GetAuthorDto>(3);
        //    authorsToSeed.ForEach(x => x.AuthorId = i++);
        //    return authorsToSeed.Select(_ => _);
        //    //authorInstance = new GetAuthorDto
        //    //{
        //    //    AuthorId = 8,
        //    //    FirstName = "SeededName",
        //    //    LastName = "SeededLast",
        //    //    Username = "Seeded@seed.de",
        //    //    Password = "Seeded123!@#"
        //    //};
        //    //return authorInstance;

        //}
        ////[Fact]
        ////public async Task ReturnBadRequestOnStateValidationFailure()
        ////{
        ////    authorInstance.Username = "";
        ////    await AssertBadRequestOnPost(author);
        ////}

        //[Fact]
        //private void GetAllAuthorsTest()
        //{
        //    //arrange
        //    var service = new Mock<IAuthorService>();
        //    var authors = GetFakeData();
        //    service.Setup(x => x.GetAllAuthors()).Returns(authors);
        //    //I needed to add another ctor to AuthorsController to accept the IAuthorService separately
        //    var controller = new AuthorsController(service.Object);

        //    //Act
        //    var results = controller.GetAll();
        //    var okResult = results as OkObjectResult;

        //    //Assert 
        //    Assert.NotNull(okResult);
        //    Assert.Equal(200, okResult.StatusCode);

        //    //solution: http://www.rovers0.xyz/fi1/moq-throw-async.html
        //}
        private HttpClient Client;
        public AuthorControllerTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client; 
        }

        [Fact]
        public async Task TestGetAuthorsAsync()
        {
            var request = "/api/Authors";
            var response = await Client.GetAsync(request);
            response.EnsureSuccessStatusCode();
        }

    }
}
