using Farhurkala_Store.Application.Services.Users.Commands.EditUser;
using Farhurkala_Store.Application.Services.Users.Commands.RegisterUser;
using Farhurkala_Store.Application.Services.Users.Commands.RemoveUser;
using Farhurkala_Store.Application.Services.Users.Commands.UserStatusChange;
using Farhurkala_Store.Application.Services.Users.Queries.GetRoles;
using Farhurkala_Store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        //یک نمونه از سرویسمون می سازیم و از آن استفاده می کنیم
        // باید حتما با اینترفیس کلاس کار کنیم
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserStatusChangeService _userStatusChangeService;
        private readonly IEditUserService _editUserService;

        //در متد سازنده اینجکت را انجام میدیم
        public UsersController(
            IGetUsersService getUsersService,
            IGetRolesService getRolesService,
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IUserStatusChangeService userStatusChangeService,
            IEditUserService editUserService
            )
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService =registerUserService;
            _removeUserService = removeUserService;
            _userStatusChangeService = userStatusChangeService;
            _editUserService = editUserService;
        }

        //روش اصولی این هست که از ویو مدل استفاده کنیم وما برای راحتی کار از دی تی ا استفاده کردیم
        public IActionResult Index(string searchkey, int page=1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto 
            { 
                Page=page,
                SearchKey=searchkey,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles =new SelectList(_getRolesService.Execute().Data,"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                Roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        Id=RoleId
                    }
                },
                Password=Password,
                RePassword= RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult UserStatusChange(long UserId)
        {
            return Json(_userStatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string Fullname,string Email)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                Email=Email,
                UserId = UserId,
            }));
        }
    }
}
