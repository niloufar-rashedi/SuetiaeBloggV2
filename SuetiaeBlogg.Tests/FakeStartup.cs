using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Authors;
using SuetiaeBlogg.Data;
using System;

namespace SuetiaeBlogg.Tests
{
    public class FakeStartup : Startup
    {
        public FakeStartup(IConfiguration configuration) : base(configuration)
        {

        }
        //Problem with overriding Configue method in inherited Interfaces, 
        //possible solution: https://github.com/justeat/AspNetCore.TestStartup/blob/master/src/AspNetCore.TestStartup/WebHostBuilderExtensions.cs
        public new void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);

            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<SuetiaeBloggDbContext>();
                if (dbContext == null)
                {
                    throw new NullReferenceException("Cannot get instance of dbContext");
                }

                if (dbContext.Database.GetDbConnection().ConnectionString.ToLower().Contains("/db"))
                {
                    throw new Exception("LIVE SETTINGS IN TESTS!");
                }

                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                //dbContext.Authors.Add(new GetAuthorDto { AuthorId = 7, FirstName = "IntegName", LastName = "IntegLastName", Username = "Integration@test.se", Password = "Integration123!@#" });
                //dbContext.Authors.Add(new Author { AuthorId = 7, FirstName = "IntegNameTwo", LastName = "IntegLastNameTwo", Username = "IntegrationTwo@test.se", Password = "IntegrationTwo123!@#" });

                dbContext.SaveChanges();
            }
        }
    }
}