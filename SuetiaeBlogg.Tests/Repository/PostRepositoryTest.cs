using System;
using System.Collections.Generic;
using System.Text;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Tests.Fakes;

namespace SuetiaeBlogg.Tests.Repository
{
    public class PostRepositoryTest
    {
        public void CanAddNewPost()
        {
            FakePostCategoriesRepository repository = new FakePostCategoriesRepository();
            var Post = new Post() { Title = "this is the first post with complete model", Body = "Write something here!" };

            var Categories = new List<Category>(){
                new Category { Name = "General" },
                new Category { Name = "Event" }
            };

            var PostCategories = new PostCategories { Post = Post, Category = Categories[0] };
            
           // repository.AddAsync(PostCategories);

        }


    }
}
