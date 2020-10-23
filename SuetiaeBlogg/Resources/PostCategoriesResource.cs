using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;

namespace SuetiaeBlogg.API.Resources
{
    public class PostCategoriesResource
    {
        
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}
