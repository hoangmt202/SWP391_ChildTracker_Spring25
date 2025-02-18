using BusinessLogic.Service.Implement;
using BusinessLogic.Service.Interface;
using Common.DTOs.Blog;
using Microsoft.AspNetCore.Mvc;


namespace HealthChildTrackerAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBlogsAsync()
        {
            var data = await blogService.GetAllBlogsAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogByIdAsync(int id)
        {
            var data = await blogService.GetBlogByIdAsync(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogRequest createBlogRequest)
        {
            try
            {
                await blogService.AddBlogAsync(createBlogRequest);
                return Ok(new { message = "Blog added successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(int id, [FromBody] UpdateBlogResquest updateBlogResquest)
        {
            var data = blogService.UpdateBlogAsync(id, updateBlogResquest);
            if (data != null)
            {
                return Ok(new { success = true, message = "Cập nhật thành công" });
            }
                return NotFound(new { success = false, message = "Không tìm thấy blog" });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var data = blogService.DeleteBlogAsync(id);
            if (data != null)
            {
                return Ok(new { success = true, message = "Xóa thành công" });
            }
            return NotFound(new { success = false, message = "Không tìm thấy blog" });
        }
    }
}
