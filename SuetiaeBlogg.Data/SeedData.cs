using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SuetiaeBloggDbContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<SuetiaeBloggDbContext>>()))
            {
                // Look for any movies.
                if (context.Posts.Any())
                {
                    return; // DB has been seeded
                }
                context.Posts.AddRange(
                new Post
                {
                    Title = "Post #1",
                    Summary = "This our first post",
                    Body = "Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,...",
                },
                new Post
                {
                    Title = "Post #2",
                    Summary = "This is our second post",
                    Body = "Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,...",
                },
                new Post
                {
                    Title = "Post #3",
                    Summary = "Hope this goes through the api",
                    Body = "Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,...",
                },
                new Post
                {
                    Title = "Post #4",
                    Summary = "Hope this goes through the api",
                    Body = "Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,Bal, bla, bla,...",
                }
                );
                context.SaveChanges();
            }
        }
    }
}
