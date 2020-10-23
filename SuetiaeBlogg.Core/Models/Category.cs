using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace SuetiaeBlogg.Core.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public IList<PostCategories> PostCategories { get; set; }
      
        
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public string Description { get; set; }

        
        
    }
}
