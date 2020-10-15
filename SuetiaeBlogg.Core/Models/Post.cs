using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        [NotMapped]
        public List<Category> Categories { get; set; } = new List<Category>();
        [Required(ErrorMessage = "Title required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Post text required")]
        public string Body { get; set; }
        public DateTimeOffset PubDate { get; set; }
        public DateTimeOffset LastModified { get; set; } = DateTimeOffset.Now;
        public bool IsPublic { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        [MaxLength(140)]
        public string Summary { get; set; }
    }
}

