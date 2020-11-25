using System;
using System.Collections.Generic;
using System.Text;
using SuetiaeBlogg.Services;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.Tests.Service
{
    public class AuthorServiceTest
    {

        [Fact]
        public async Task ShouldFindAllAuthorsInDatabase()
        {
            var client = new ClientProviderTest().Client;
            var response = await client.GetAsync("api/[controller]");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ShouldCreateAuthorAndPasswords()
        {
            using (var client = new ClientProviderTest().Client)
            {
                var response = await client.PostAsync("/api/Authors"
                        , new StringContent(
                        JsonConvert.SerializeObject(new Author()
                        {
                            FirstName = "Niloufar",
                            LastName = "Rashedi",
                            Username = "Niloo@test.se"
            }),
                    Encoding.UTF8,
                    "application/json"));

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
        //[Fact]
        //public void ShouldFindAuthor()
        //{
        //    IEnumerable<Core.Models.Author> author = (IEnumerable<Core.Models.Author>)_context.Authors.Find();
        //    Assert.NotEmpty(author);
        //}


    }
}
