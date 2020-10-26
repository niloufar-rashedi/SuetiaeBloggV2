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
                
                if (context.Posts.Any())
                {
                    return; // DB has been seeded
                }

                var post1 = new Post
                {
                    Author = new Author
                    {
                        Name = "EttoreM"
                    },
                    Title = "This is the first post with complete model and author",
                    Summary = "This is what I want to see in the homepage",
                    Body = "Write something here!"};
                var comment = new Comment { 
                    Body = "my first comment", 
                    Author = new Author { 
                        Name ="anna77" }, 
                    Post = post1 };
                var category1 = new Category { 
                    Name = "General"};
                var tag1 = new Tag {
                    Name = "Fika" };
                var tag2 = new Tag {
                    Name = "Event" };
                var postCategory1 = new PostCategories { 
                    Post = post1, 
                    Category = category1 };
                var postTag1 = new PostTags { 
                    Post = post1, 
                    Tag = tag1 };
                var postTag2 = new PostTags { 
                    Post = post1, 
                    Tag = tag2 };

                var post2 = new Post { 
                    Author = new Author { 
                        Name = "AlbertoM" }, 
                    Title = "This is the second post with complete model and author",
                    Summary = "This is what I want to see in the homepage",
                    Body = "Write something here!" };
                var category2 = new Category { Name = "National holiday" };
                var postCategory2 = new PostCategories { Post = post2, Category = category1 };
                var postCategory3 = new PostCategories { Post = post2, Category = category2 };
                var postTag3 = new PostTags { Post = post2, Tag = tag2 };

                context.PostCategories.AddRange(postCategory1, postCategory2, postCategory3);
                context.PostTags.AddRange(postTag1, postTag2, postTag3);
                context.Comments.Add(comment);
                
                context.SaveChanges();
                
            }
        }
    }
}
