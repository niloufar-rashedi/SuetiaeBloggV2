using System;
using System.Collections.Generic;
using System.Text;
using SuetiaeBlogg.Core.Models.Authors;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.Comments;
using SuetiaeBlogg.Core.Models.Tags;

namespace SuetiaeBlogg.Core.Models.Posts
{
    public class GetPostHeadlineDto
    {
        public int Id { get; set; }
        public GetAuthorDto Author { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public List<GetCategoryDto> Categories { get; set; }
        public List<GetTagDto> Tags { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public int CommentsCount { get; set;}
    }
}
