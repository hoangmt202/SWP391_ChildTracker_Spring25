using BusinessLogic.DTOs.Authentication;
using BusinessLogic.Services.Interfaces;
using DataAccess.Models;
using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementations
{
    public class AuthSerivce : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthSerivce(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> LoginAsync(LoginRequestDTO request)
        {
            var userRepository = _unitOfWork.GetRepository<User>();

            var user = await userRepository.GetAsync(u =>
                (u.Username == request.UsernameOrEmail || u.Email == request.UsernameOrEmail)
                && u.Password == request.Password
                && u.Status == true);

            if (user == null)
            {
                throw new Exception("Tên đăng nhập/email hoặc mật khẩu không đúng");
            }

            return user;
        }
        public async Task<User> RegisterAsync(RegisterRequestDTO request)
        {
            var userRepository = _unitOfWork.GetRepository<User>();

            // Kiểm tra username đã tồn tại
            var existingUsername = await userRepository.AnyAsync(u => u.Username == request.Username);
            if (existingUsername)
            {
                throw new Exception("Tên đăng nhập đã tồn tại");
            }

            // Kiểm tra email đã tồn tại
            var existingEmail = await userRepository.AnyAsync(u => u.Email == request.Email);
            if (existingEmail)
            {
                throw new Exception("Email đã tồn tại");
            }

            var user = new User
            {
                Username = request.Username,
                Password = request.Password, // Nên hash password trước khi lưu
                Email = request.Email,
                FullName = request.FullName,
                Phone = request.Phone,
                Address = request.Address,
                Role = "User", // Role mặc định
                Status = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await userRepository.AddAsync(user);
            await userRepository.SaveAsync();

            return user;
        }
        public async Task LogoutAsync(int userId)
        {
            await Task.CompletedTask;
        }
    }
}
