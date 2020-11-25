using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using SuetiaeBlogg.Tests.Helper;
using Xunit;
using System;

namespace SuetiaeBlogg.Tests
{
    public class AuthorsControllerTests : IClassFixture<WebApplicationFactory<SuetiaeBlogg.Startup>>
        //: TestBase
    {
        //public AuthorsControllerTests(TestApplicationFactory<FakeStartup> factory) : base(factory)
        //{ }
        private readonly WebApplicationFactory<SuetiaeBlogg.Startup> _factory;
        public AuthorsControllerTests(WebApplicationFactory<SuetiaeBlogg.Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("/api/BlogPosts")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            //var provider = TestClaimsProvider.WithUserClaims();
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        //Expects 401 status code: unauthorized user
        [Theory]
            [InlineData("api/Authors")]
            public async Task Get_EndPointsReturnsFailureForUnauthorizedUser(string url)
            {
                var provider = TestClaimsProvider.WithUserClaims();
                var client = _factory.CreateClientWithTestAuth(provider);

                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
            }
        //https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-5.0
    }
}
