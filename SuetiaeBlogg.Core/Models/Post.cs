using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public IList<PostCategory> PostsCategories { get; set; }
        //public IList<Category> Categories { get; set; }
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

