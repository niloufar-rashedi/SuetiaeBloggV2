using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Models.Tags;

namespace SuetiaeBlogg.Core.Services
{
    public interface ITagService
    {
        public Task<ServiceResponse<IEnumerable<GetPostDto>>> FindPostsByTagId(int tagId);
        public Task<ServiceResponse<IEnumerable<GetTagDto>>> GetAllTags();

    }
}
