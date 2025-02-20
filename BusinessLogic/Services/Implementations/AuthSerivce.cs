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
    }
}
