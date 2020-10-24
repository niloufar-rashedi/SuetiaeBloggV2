using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string Name { get; set; }
        public string Urlslug { get; set; }
        public string Description { get; set; }
        public IList<PostTags> PostTags { get; set; }
    }
}
