using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SuetiaeBlogg.API.Resources;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Authors;
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
            
            CreateMap<Category, GetCategoryDto>();
            CreateMap<Tag, GetTagDto>();
            CreateMap<Author, GetAuthorDto>();
            CreateMap<GetAuthorDto, Author>();
            CreateMap<Post, GetPostDto>()
            .ForMember(dto => dto.FirstName, c => c.MapFrom(c => c.Author.FirstName))
            .ForMember(dto => dto.Categories, c => c.MapFrom(c => c.PostCategories.Select(cs => cs.Category)))
            .ForMember(dto => dto.Tags, c => c.MapFrom(c => c.PostTags.Select(cs => cs.Tag)));
            CreateMap<Post, AddPostDto>()
            .ForMember(dto => dto.Category, c => c.MapFrom(c => c.PostCategories.Select(cs => cs.Category.Name)));
            CreateMap<Comment, GetCommentDto>()
             .ForMember(dto => dto.Author, c => c.MapFrom(c => c.Author.AuthorId));
            CreateMap<GetCommentsCountDto, GetPostHeadlineDto>();
        }
    }
}
