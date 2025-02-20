using BusinessLogic.DTOs.Authentication;
using BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO request)
        {
            try
            {
                var user = await _authService.RegisterAsync(request);

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

        [Authorize] // Yêu cầu xác thực
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Lấy userId từ token (giả sử đã setup authentication)
                var userId = int.Parse(User.FindFirst("userId")?.Value);
                await _authService.LogoutAsync(userId);

                return Ok(new { message = "Đăng xuất thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}