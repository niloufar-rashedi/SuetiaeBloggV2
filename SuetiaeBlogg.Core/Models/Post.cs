using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
       
        public IList<PostCategories> PostCategories { get; set; }
        public IList<PostTags> PostTags { get; set; }
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        
        [Required(ErrorMessage = "Title required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Post text required")]
        public string Body { get; set; }
        [MaxLength(140)] 
        public string Summary { get; set; }
        public Author Author { get; set; }
        public string Meta { get; set; }
        public string UrlSlug { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset PubDate { get; set; } = DateTimeOffset.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset LastModified { get; set; } = DateTimeOffset.Now;
        public bool IsPublic { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        
        
    }
}

