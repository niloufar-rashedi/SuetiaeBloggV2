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

                var category1 = new Category { Name = "General" };
                var category2 = new Category { Name = "Event" };
                var category3 = new Category { Name = "Sverige" };
                var category4 = new Category { Name = "Nationaldag" };
                var category5 = new Category { Name = "Historia" };
                       
                context.Categories.AddRange(category1, category2, category3, category4, category5);

                var tag1 = new Tag { Name = "General" };
                var tag2 = new Tag { Name = "Väder" };
                var tag3 = new Tag { Name = "Natur" };
                
                context.Tags.AddRange(tag1, tag2, tag3);

                var author1 = new Author { FirstName = "Anna" };
                var author2 = new Author { FirstName = "Evelyn" };
                var author3 = new Author { FirstName = "Niloufar" };

                

                context.Authors.AddRange(author1, author2, author3);
                
                
                var post1 = new Post
                {

                    Author = author1,
                    Title = "This is the first post with complete model and author",
                    Summary = "This is what I want to see in the homepage",
                    Body = "Write something here!",
                    
                };
                var post2 = new Post
                {

                    Author = author2,

                    Title = "This is the first post with complete model and author",
                    Summary = "This is what I want to see in the homepage",
                    Body = "Write something here!",
                    

                };
                
                var postCategory1 = new PostCategories { 
                    Post = post1, 
                    Category = category1 };
                var postTag1 = new PostTags { 
                    Post = post1, 
                    Tag = tag1 };
                var postTag2 = new PostTags { 
                    Post = post1, 
                    Tag = tag2 };

                var post3 = new Post { 
                    Author = new Author {
                        FirstName = "AlbertoM" }, 

                    Title = "This is the second post with complete model and author",
                    Summary = "This is what I want to see in the homepage",
                    Body = "Alla Västtrafiks expressbussar till Göteborg ska byta namn och utseende." +
                    "Först ut är Gul, Blå och Rosa express som får nya namn och rutter redan i december. " +
                    "Förändringar som inte tas emot väl av alla."+
                    "– Det känns som ett misslyckande i planeringen"+
                    "säger Anna Andrén som är en av dem som drabbas.!",
                    


                };
                var post4 = new Post
                {
                    Author = author3,
                    Title = "This is the third post with complete model and author",
                    Summary = "This is what I want to see in the homepage",
                    Body = "Flera av stadens anställda varnar för att smittspridningen åter tagit fart inom stadens verksamheter" +
                    ". Även fast antalet smittade fortfarande är lågt jämfört med sommarens siffror, så uppmanar nu Babbs Edberg, " +
                    "stadsdelsdirektör i Majorna-Linné och Centrum, till att ta riskerna på allvar.",
                    
                };

                var comment1 = new Comment
                {
                    Body = "I would like to write something mre original but anyway this a comment in the first post",
                    Author = author3,
                    Post = post1
                };
                var comment2 = new Comment
                {
                    Body = "I think the comment goes with every post.",
                    Author = author1,
                    Post = post1
                };
                var comment3 = new Comment
                {
                    Body = "I completely disagree, it is a complotto!",
                    Author = author2,
                    Post = post3
                };
                var comment4 = new Comment
                {
                    Body = "ok, loooks nice. Where is the author name for the comment?",
                    Author = author1,
                    Post = post4
                };


                var postCategory2 = new PostCategories {Post = post1, Category = category2};
                var postCategory3 = new PostCategories {Post = post1, Category = category3};
                var postCategory4 = new PostCategories { Post = post2, Category = category4 };
                var postCategory5 = new PostCategories { Post = post2, Category = category5 };
                var postCategory6 = new PostCategories { Post = post2, Category = category2 };
                var postCategory7 = new PostCategories { Post = post3, Category = category4 };
                var postCategory8 = new PostCategories { Post = post3, Category = category2 };
                var postCategory9 = new PostCategories { Post = post3, Category = category3 };
                var postCategory10 = new PostCategories { Post = post4, Category = category1 };

                var postTag3 = new PostTags {Post = post2, Tag = tag2 };
                var postTag4 = new PostTags {Post = post3, Tag = tag3 };
                var postTag5 = new PostTags { Post = post3, Tag = tag2 };

                context.Comments.AddRange(comment1, comment2, comment3, comment4);

                context.PostCategories.AddRange(postCategory1, postCategory2, postCategory3);
                context.PostCategories.AddRange(postCategory4, postCategory5, postCategory6);
                context.PostCategories.AddRange(postCategory7, postCategory8, postCategory9, postCategory10);
                context.PostTags.AddRange(postTag1, postTag2, postTag3, postTag4, postTag5);
                context.AddRange(post1, post2, post3, post4);
                
                context.SaveChanges();
                
            }
        }
    }
}
