using System;
using System.Collections.Generic;
using System.Text;

namespace SuetiaeBlogg.Core.Models.Comments
{
    public class GetCommentsCountDto
    {
        public Post Post { get; set; } 
        public int CommentsCount { get; set; }
    
    }
}
