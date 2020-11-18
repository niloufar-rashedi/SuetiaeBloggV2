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
        private readonly SuetiaeBloggDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IPostRepository _postRepository;
        private readonly IPostCategoriesRepository _postcategoriesRepository;

        public PostService(SuetiaeBloggDbContext context, IMapper mapper, 
            IPostRepository postRepository, IPostCategoriesRepository postCategoriesRepository, ICategoryService categoryService, IAuthorService authorService)
        {
            this._context = context;
            this._mapper = mapper;
            this._categoryService = categoryService;
            this._authorService = authorService;
            this._postRepository = postRepository;
            this._postcategoriesRepository = postCategoriesRepository;
        }
        public async Task<ServiceResponse<IEnumerable<GetPostDto>>> GetPosts()
        {
            ServiceResponse<IEnumerable<GetPostDto>> response = new ServiceResponse<IEnumerable<GetPostDto>>();
            try
            {
                var posts = await _postRepository.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<GetPostDto>>(posts);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public  async Task<ServiceResponse<GetPostDto>> FindPostById(int postId)
        {
            ServiceResponse<GetPostDto> response = new ServiceResponse<GetPostDto>();
            try
            {
                var post = await _postRepository.GetPostByIdAsync(postId);
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
                var author = await _authorService.FindAuthorById(newPost.AuthorId);
                var post = new Post()
                {
                    Author = author,
                    Title = newPost.Title,
                    Summary = newPost.Summary,
                    Body = newPost.Body,
                    LastModified = newPost.LastModified
                };
                _context.SaveChanges();

                //now checks which category has been specified
                if (!string.IsNullOrEmpty(newPost.Category))
                {
                ////finds the category object that corresponds to the category name received
                ////just one category is added from the frontend
                     var query = await _categoryService.FindCategoryByName(newPost.Category);
                     if (!query.Success)
                    {
                        response.Message = "There has been a problem retrieving the category";
                    }
                    var category = query.Data.FirstOrDefault();
                    var postCategory = new PostCategories
                    {
                        Post = post,
                        Category = category
                    };
                   _context.PostCategories.Add(postCategory);
                }
                else
                {
            //        //assign the default category as General that is the category with Id 1
                   var category = await _context.Categories.Where(c => c.CategoryId == 1)
                                            .ToListAsync();
                    var postCategory = new PostCategories
                    {
                        Post = post,
                        Category = category.FirstOrDefault()
                    };
                    _context.PostCategories.Add(postCategory);
                }
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
        public async Task<ServiceResponse<Post>> UpdatePost(int postId, AddPostDto postToBeUpdated)
        {
            ServiceResponse<Post> response = new ServiceResponse<Post>();
            try
            {
                var post = _postRepository.GetByID(postId);
                if (post == null)
                {
                    response.Message = "Post not found";
                }

                post.Title = postToBeUpdated.Title;
                post.Summary = postToBeUpdated.Summary;
                post.Body = postToBeUpdated.Body;
                post.LastModified = postToBeUpdated.LastModified;
                
                
                //var postCategory =  await _postcategoriesRepository.GetPostCategoryByCategoryNameAsync(postToBeUpdated.Category);
                //post.PostCategories = category;
                
                 

                

                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<Post>(post);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
        
        public async Task<ServiceResponse<Task>> DeletePost(int postId)
        {
            ServiceResponse<Task> response = new ServiceResponse<Task>();
            try
            {
                _postRepository.Delete(postId);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
           
        }
        public async Task<ServiceResponse<Task>> CreateComment(int postId, AddCommentDto newComment)
        {
            ServiceResponse<Task> response = new ServiceResponse<Task>();
            try
            {
                var post = _postRepository.GetByID(postId);
                var author = await _authorService.FindAuthorById(newComment.AuthorId);
                if (post == null)
                {
                    response.Message = "Post not found";
                }
                var comment = new Comment
                {
                    Author = author,
                    Body = newComment.Body,
                    PubDate = newComment.PubDate,
                    Post = post
                };
                await _context.AddAsync(comment);
                await _context.SaveChangesAsync();
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
