using SuetiaeBlogg.Core.Models.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SuetiaeBlogg.Core.Models.Posts
{
    public class AddPostDto
    {
        
        [Required(ErrorMessage = "Title required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Post text required")]
        public string Body { get; set; }
        [MaxLength(140)]
        public string Summary { get; set; }
        public List<GetCategoryDto> Categories { get; set; }

        public DateTimeOffset LastModified { get; set; } = DateTimeOffset.Now;
        

    }
}
