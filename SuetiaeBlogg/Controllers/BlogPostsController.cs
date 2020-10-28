using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using SuetiaeBlogg.API.Resources;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Categories;
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

        public BlogPostsController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        

        /// <summary>
        /// Retrieves all posts with details
        /// </summary>
        [HttpGet]
        //[Route("AllPostsDetails")]
        public async Task<ActionResult<IEnumerable<GetPostDto>>> GetAllPosts()
        {
            var posts = await _postService.GetAllComplete();

            return Ok(posts);
        }

        /// <summary>
        /// Retrieves a post by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetPostDto>> GetPostById(int Id)
        {
            var posts = await _postService.GetPostById(Id);
            return Ok(posts);
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
            var posts = await _postService.FindPostsByTagId(tagId);

            return Ok(posts);

        }
        /// <summary>
        /// Retrieves posts by authorId
        /// </summary>
        [HttpGet("~/api/[controller]/authors/{authorId:int}/posts")]
        public async Task<ActionResult<IEnumerable<GetPostDto>>> GetPostByAuthor(int authorId)
        {
            var posts = await _postService.FindPostsByAuthorId(authorId);

            return Ok(posts);

        }

        /// <summary>
        /// Retrieves all categories
        /// </summary>

        [HttpGet("~/api/[controller]/categories/")]
        public async Task<ActionResult<IEnumerable<GetCategoryDto>>> GetCategories()
        {
            var categories = await _categoryService.GetAllCategories();

            return Ok(categories);

        }

        // POST: api/BlogPosts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        [HttpPost]
        [Route("InsertNewPost")]
        public async Task<ActionResult<GetPostDto>> AddPost([FromBody] AddPostDto post)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            await _postService.CreatePost(post);
            return Ok();

        }



        // GET: api/Posts/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Post>> GetPost(int id)
        //{
        //    var post = await _postService.Posts.FindAsync(id);

        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return post;
        //}

        // PUT: api/Posts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPost(int id, Post post)
        //{
        //    if (id != post.PostId)
        //    {
        //        return BadRequest();
        //    }

        //    _postService.Entry(post).State = EntityState.Modified;

        //    try
        //    {
        //        await _postService.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PostExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        // DELETE: api/Posts/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Post>> DeletePost(int id)
        //{
        //    var post = await _postService.Posts.FindAsync(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    _postService.Posts.Remove(post);
        //    await _postService.SaveChangesAsync();

        //    return post;
        //}

        //private bool PostExists(int id)
        //{
        //    return _postService.Posts.Any(e => e.PostId == id);
        //}

        ///// <summary>
        ///// Add a category to an existing post
        ///// </summary>
        //[HttpPost]
        //public async Task<IActionResult> AddPostCategory(AddPostCategoryDto newPostCategory)
        //{
        //    return Ok(await _categoryService.AddCategoryToAPost(newPostCategory));
        //}
    }
}
