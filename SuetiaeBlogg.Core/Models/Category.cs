using System;
using System.Collections.Generic;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        public IList<Post> Posts { get; set; }
    }
}
