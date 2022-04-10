using System.Collections.Generic;

namespace Farhurkala_Store.Application.Services.Users.Commands.RegisterUser
{
    //ورودی های سرویس ثبت نام کاریر
    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }

        public List<RolesInRegisterUserDto> Roles { get; set; }
    }
}
