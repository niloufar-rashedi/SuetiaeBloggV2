using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;

namespace SuetiaeBlogg.Services.Services
{
    public class TagService : ITagService
    {
        private readonly SuetiaeBloggDbContext _context;
        private readonly IMapper _mapper;

        public TagService(SuetiaeBloggDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<GetPostDto>>> FindPostsByTagId(int tagId)
        {
            ServiceResponse<IEnumerable<GetPostDto>> response = new ServiceResponse<IEnumerable<GetPostDto>>();
            try
            {
                var postIds = await _context.PostTags
                                    .Where(c => c.TagId == tagId)
                                    .Select(x => x.PostId)
                                    .Distinct()
                                    .ToListAsync();
                
                var posts = await _context.Posts
                                .Where(x => postIds.Contains(x.PostId))
                                .Include(a => a.Author)
                                .Include(c => c.PostCategories)
                                .ThenInclude(Postcategories => Postcategories.Category)
                                .Include(t => t.PostTags)
                                .ThenInclude(PostTags => PostTags.Tag)
                                .Include(t => t.Comments)
                                .ToListAsync();

                if (posts == null)
                {
                    response.Message = "No posts found in this category";
                }
                else
                    response.Data = _mapper.Map<IEnumerable<GetPostDto>>(posts);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
    
}
