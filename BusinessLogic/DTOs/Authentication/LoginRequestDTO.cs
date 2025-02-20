using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class LoginRequestDTO
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
