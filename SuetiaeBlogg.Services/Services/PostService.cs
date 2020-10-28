﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.Comments;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Repositories;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;

namespace SuetiaeBlogg.Services.Services
{
    public class PostService : IPostService
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly SuetiaeBloggDbContext _context;
        private readonly IMapper _mapper;


        public PostService(SuetiaeBloggDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<GetPostDto>>> GetAllComplete()
        {
            ServiceResponse<IEnumerable<GetPostDto>> response = new ServiceResponse<IEnumerable<GetPostDto>>();
            try
            {
                var posts = await _context.Posts
                                    .Include(a => a.Author)
                                    .Include(c => c.PostCategories)
                                    .ThenInclude(Postcategories => Postcategories.Category)
                                    .Include(t => t.PostTags)
                                    .ThenInclude(PostTags => PostTags.Tag)
                                    .Include(t => t.Comments)
                                    .AsNoTracking()
                                    .ToListAsync();


                response.Data = _mapper.Map<IEnumerable<GetPostDto>>(posts);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public  async Task<ServiceResponse<GetPostDto>> GetPostById(int postId)
        {
            ServiceResponse<GetPostDto> response = new ServiceResponse<GetPostDto>();
            try
            {
                var post = await _context.Posts
                                    .Where(d => d.PostId == postId)
                                    .Include(a => a.Author)
                                    .Include(c => c.PostCategories)
                                    .ThenInclude(Postcategories => Postcategories.Category)
                                    .Include(t => t.PostTags)
                                    .ThenInclude(PostTags => PostTags.Tag)
                                    .Include(t => t.Comments)
                                    .FirstOrDefaultAsync();
                                     


                if (post == null)
                {
                    response.Message = "Post not found";
                }
                else
                    response.Data = _mapper.Map<GetPostDto>(post);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<Post>> CreatePost(AddPostDto newPost)

        {
            ServiceResponse<Post> response = new ServiceResponse<Post>();
            try
            {
                _context.Posts.Add(new Post()
                {
                    Title = newPost.Title,
                    Summary = newPost.Summary,
                    Body = newPost.Body,
                    LastModified = newPost.LastModified
                });
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<Post>(newPost);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;


        }
        public ServiceResponse<Task> UpdatePost(Post postToBeUpdated, Post post)
        {
            throw new NotImplementedException();
        }
        public ServiceResponse<Task> DeletePost(Post post)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<Post>> FindPostsByAuthorId(int authorId)
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<Post>> FindPostsByTagId(int tagId)
        {
            throw new NotImplementedException();
        }
    }
}
