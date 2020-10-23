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
using SuetiaeBlogg.Core.Services;
using SuetiaeBlogg.Data;

namespace SuetiaeBlogg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly SuetiaeBloggDbContext _context;
        private readonly IPostCategoryService _postCategoryService;
        //private readonly IPostService _postService;
        //private readonly IMapper _mapper;

        //public BlogPostsController(IPostService postService, IMapper mapper)
        //{
        //    _postService = postService;
        //    _mapper = mapper;}

        public BlogPostsController(IPostCategoryService postCategoryService)
        {
            _postCategoryService = postCategoryService;
        }
       
        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            var posts = await _postCategoryService.GetAllWithCategories();

            return Ok(posts);
            //var postResources = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResource>>(posts);
            //return Ok(postResources);

            //var posts = await _postService.GetAllWithCategories();
            //return Ok(posts);


            
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

        // POST: api/Posts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Post>> PostPost(Post post)
        //{
        //    _postService.Posts.Add(post);
        //    await _postService.SaveChangesAsync();

        //    return CreatedAtAction("GetPost", new { id = post.PostId }, post);
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
    }
}
