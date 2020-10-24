﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        
        [Required(ErrorMessage = "Name required")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "Comment text required")]
        public string Body { get; set; }
        public DateTimeOffset PubDate { get; set; } = DateTimeOffset.Now;
        public bool IsPublic { get; set; }
        //public int PostId { get; set; }
        public Post Post { get; set; }
         
    }
}
