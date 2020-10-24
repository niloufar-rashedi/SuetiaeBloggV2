using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuetiaeBlogg.Core.Models.PostCategory
{
    public class AddPostCategoryDto
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
    }
}
