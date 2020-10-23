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

                var post = new Post { Title = "this is the first post with complete model", Body = "Write something here!" };
                var comment = new Comment { Body = "my first comment", AuthorName = "anna77", Post = post };
                var category1 = new Category { Name = "General"};
                var tag1 = new Tag {Name = "Fika" };
                var tag2 = new Tag {Name = "Event" };
                var postCategory1 = new PostCategories { Post = post, Category = category1 };
                var postTag1 = new PostTags { Post = post, Tag = tag1 };
                var postTag2 = new PostTags { Post = post, Tag = tag2 };

                context.PostCategories.Add(postCategory1);
                //context.Entry<PostCategories>(postCategory1).State = EntityState.Detached;
                
                context.PostTags.AddRange(postTag1, postTag2);
                //context.Entry<PostTags>(postTag1).State = EntityState.Detached;
                //context.Entry<PostTags>(postTag2).State = EntityState.Detached;

                context.Comments.Add(comment);
                //context.Entry<Comment>(comment).State = EntityState.Detached;

                context.SaveChanges();
                
            }
        }
    }
}
