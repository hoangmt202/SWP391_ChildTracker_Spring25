using BusinessLogic.Services.Interfaces;
using Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthChildTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        // Allow all users to view blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogDTO>>> GetAllBlogs()
        {
            return Ok(await _blogService.GetAllBlogsAsync());
        }

        // Allow all users to view a specific blog
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogDTO>> GetBlog(int id)
        {
            return Ok(await _blogService.GetBlogByIdAsync(id));
        }

        // Only Admin and Doctor can create a blog
        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> CreateBlog(BlogDTO blogDTO)
        {
            await _blogService.AddBlogAsync(blogDTO);
            return CreatedAtAction(nameof(GetBlog), new { id = blogDTO.BlogId }, blogDTO);
        }

        // Only Admin and Doctor can update a blog
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateBlog(int id, BlogDTO blogDTO)
        {
            await _blogService.UpdateBlogAsync(blogDTO);
            return NoContent();
        }

        // Only Admin and Doctor can delete a blog
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogService.DeleteBlogAsync(id);
            return NoContent();
        }
    }
}
