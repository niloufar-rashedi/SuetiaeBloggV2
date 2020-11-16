﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SuetiaeBlogg.Core.Models.Comments
{
    public class GetCommentDto
    {
        public int CommentId { get; set; }
        public string Body { get; set; }
        public Author Author { get; set; }
        public DateTimeOffset PubDate { get; set; } 
        
    }
}
