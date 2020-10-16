using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public IList<PostCategory> PostsCategories { get; set; }
        //public IList<Post> Posts { get; set; }
    }
}
