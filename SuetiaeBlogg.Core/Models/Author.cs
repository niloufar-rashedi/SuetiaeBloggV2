using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
        public class Author
        {
            public int AuthorId { get; set; }
            [Required]
            public string Name { get; set; }
        }
   
}
