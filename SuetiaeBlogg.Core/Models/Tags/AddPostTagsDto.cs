using System;
using System.Collections.Generic;
using System.Text;

namespace SuetiaeBlogg.Core.Models.Tags
{
    public class AddPostTagsDto
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
    }

}
