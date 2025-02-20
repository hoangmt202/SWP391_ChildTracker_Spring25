using BusinessLogic.DTOs.Authentication;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthChildTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService userService)
        {
            _authService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            try
            {
                var user = await _authService.LoginAsync(request);

                // Tạo response object, bỏ đi các thông tin nhạy cảm
                var response = new
                {
                    user.UserId,
                    user.Username,
                    user.Email,
                    user.FullName,
                    user.Role,
                    user.Status
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}