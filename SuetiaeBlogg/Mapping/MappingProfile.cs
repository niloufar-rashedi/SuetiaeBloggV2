using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SuetiaeBlogg.API.Resources;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.Comments;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Models.Tags;

namespace SuetiaeBlogg.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Post, PostResource>();
            CreateMap<Category, CategoryResource>();

            // Resource to Domain
            CreateMap<PostResource, Post>();
            CreateMap<CategoryResource, Category>();

            CreateMap<Category, GetCategoryDto>();
            CreateMap<Tag, GetTagDto>();
            CreateMap<Comment, GetCommentDto>();



            CreateMap<Post, GetPostDto>()
    .ForMember(dto => dto.Categories, c => c.MapFrom(c => c.PostCategories.Select(cs => cs.Category)))
    .ForMember(dto => dto.Tags, c => c.MapFrom(c => c.PostTags.Select(cs => cs.Tag)));
     








        }
    }
}
