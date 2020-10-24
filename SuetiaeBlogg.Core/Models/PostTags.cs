using System;
using System.Collections.Generic;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
    public class PostTags
    {
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
