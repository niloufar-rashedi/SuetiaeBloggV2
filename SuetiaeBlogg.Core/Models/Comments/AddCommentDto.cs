using System;
using System.Collections.Generic;
using System.Text;

namespace SuetiaeBlogg.Core.Models.Comments
{
    public class AddCommentDto
    {
        public int AuthorId { get; set; }
        public string Body { get; set; }
        public DateTimeOffset PubDate { get; set; } = DateTimeOffset.Now;
        
    }
}
