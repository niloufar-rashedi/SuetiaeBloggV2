﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Models.Posts;

namespace SuetiaeBlogg.Core.Services
{
    public interface IPostService
    {
        

        public Task<ServiceResponse<IEnumerable<GetPostDto>>> GetPosts();
        public Task<ServiceResponse<Post>> CreatePost(AddPostDto newPost);
        public ServiceResponse<Task> UpdatePost(Post postToBeUpdated, Post post);
        public ServiceResponse<Task> DeletePost(int Id);
        public Task<ServiceResponse<GetPostDto>> FindPostById(int Id);
        public Task<ServiceResponse<GetPostDto>> FindPostByDate(DateTime pubdate);




    }
}
