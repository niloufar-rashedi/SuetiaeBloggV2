using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuetiaeBlogg.Core.Models.PostCategory;
using SuetiaeBlogg.Core.Services;

namespace SuetiaeBlogg.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogPostCategoryController : ControllerBase
    {
        private readonly IPostCategoryService _postCategoryService;
        public BlogPostCategoryController(IPostCategoryService postCategoryService)
        {
            _postCategoryService = postCategoryService;
        }
        [HttpPost]
        public async Task<IActionResult> AddPostCategory(AddPostCategoryDto newPostCategory)
        {
            return Ok(await _postCategoryService.AddPostCategory(newPostCategory));
        }
    }
}
