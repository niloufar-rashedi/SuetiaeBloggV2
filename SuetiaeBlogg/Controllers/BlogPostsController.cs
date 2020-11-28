using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuetiaeBlogg.API.Resources;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Authors;
using SuetiaeBlogg.Core.Models.Categories;
using SuetiaeBlogg.Core.Models.Comments;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Models.Posts;
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;



namespace SuetiaeBlogg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {

        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IAuthorService _authorService;
        private readonly ILogger<BlogPostsController> _logger;
        
        public BlogPostsController(IPostService postService, ICategoryService categoryService, 
            ITagService tagService, IAuthorService authorService, ILogger<BlogPostsController> logger)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _authorService = authorService;
            _logger = logger;
        }

        // <summary>
        // Retrieves all posts with details
        // </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPostDto>>> GetAllPosts()
        {
            _logger.LogInformation("Called GetAllPOsts");
            var posts = await _postService.GetPosts();
            return Ok(posts);
        }

        // <summary>
        // Retrieves a post by postId
        // </summary>
        [HttpGet("/api/[controller]/{Id}")]
        public async Task<ActionResult<GetPostDto>> GetPostById(int Id)
        {

            var post = await _postService.GetPostById(Id);
            return Ok(post);
        }

        /// <summary>
        /// Retrieves posts by categoryId
        /// </summary>
        [HttpGet("~/api/[controller]/categories/{categoryId:int}/posts")]
        public async Task<ActionResult<IEnumerable<GetPostDto>>> GetPostsByCategories(int categoryId)
        {
            var posts = await _categoryService.FindPostsByCategoryId(categoryId);

            return Ok(posts);

        }
        
        /// <summary>
        /// Retrieves posts by tagId
        /// </summary>
        [HttpGet("~/api/[controller]/tags/{tagId:int}/posts")]
        public async Task<ActionResult<IEnumerable<GetPostDto>>> GetPostsByTags(int tagId)
        {
            var posts = await _tagService.FindPostsByTagId(tagId);

            return Ok(posts);

        }
        
        /// <summary>
        /// Retrieves posts by authorId
        /// </summary>
        [HttpGet("~/api/[controller]/authors/{authorId:int}/posts")]
        public async Task<ActionResult<IEnumerable<GetPostDto>>> GetPostByAuthor(int authorId)
        {
            var posts = await _authorService.FindPostsByAuthorId(authorId);

            return Ok(posts);

        }


        // <summary>
        // Retrieves all categories
        // </summary>
        [HttpGet("~/api/[controller]/categories")]
        public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetCategories();

            return Ok(categories);

        }

        // <summary>
        // Retrieves all tags
        // </summary>
        [HttpGet("~/api/[controller]/tags/")]
        public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetTags()
        {
            var categories = await _tagService.GetAllTags();

            return Ok(categories);

        }
        
        /// <summary>
        /// Retrieves all authors
        /// </summary>
        [HttpGet("~/api/[controller]/authors/")]
        public async Task<ActionResult<IEnumerable<GetAuthorDto>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthors();

            return Ok(authors);

        }

        /// <summary>
        /// Inserts a new post
        /// </summary>
        [HttpPost]
        [Authorize]
        [Route("InsertNewPost")]
        public async Task<ActionResult<GetPostDto>> AddPost([FromBody] AddPostDto post)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            await _postService.CreatePost(post);
            return Ok();

        }

        /// <summary>
        /// Modifies an existing post
        /// </summary>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GetPostDto>> PutPost(int id, [FromBody] AddPostDto post)
        {
            await _postService.UpdatePost(id, post);
            return Ok();
        }

        /// <summary>
        /// Inserts a comment within a post
        /// </summary>
        [HttpPut]
        [Authorize]
        [Route("{postId}/InsertNewComment/")]
        public async Task<ActionResult<GetPostDto>> AddComment(int postId, [FromBody] AddCommentDto comment)
        {
            await _postService.CreateComment(postId, comment);
            return Ok();
        }

        /// <summary>
        /// Deletes a post
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GetPostDto>> DeletePost(int id)
        {
            await _postService.DeletePost(id);
            return Ok();
        }
    }
}
