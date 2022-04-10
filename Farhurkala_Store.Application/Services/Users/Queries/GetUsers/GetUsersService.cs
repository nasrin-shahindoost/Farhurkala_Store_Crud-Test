using Farhurkala_Store.Application.Interfaces.Contexts;
using Farhurkala_Store.Common;
using System.Collections.Generic;
using System.Linq;

namespace Farhurkala_Store.Application.Services.Users.Queries.GetUsers
{
    //کلاسی که سرویس مارا پیاده سازی می کنه
    public class GetUsersService : IGetUsersService
    {
        //باید به دیتابیس وصل بشیم و چون در لایه ی پرسیستنس می باشد
        //و ما نمیتونم از لایه پایین به بالا دسترسی داشته باشیم
        //پس  یک نمونه از اینترفیس دیتابیس می سازیم و به دیتابیس متصل می شیم
        private readonly IDataBaseContext _context;

        // در این متد سازنده اینجکشین را انجام می دهیم
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            //کوئری را ایجاد می کنه ولی هنوز سمت دیتابیس نمیره
            var users = _context.Users.AsQueryable();
            //اگر مقدار سرچ وارد بشه برای ما این جستجو را انجام میده
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }
            
            //قبل از اینکه کوئری را به لیست تبدیل کنه
            // میایم پیجینیشن را انجام میدیم که فقط یه تعداد را به مانشان بده و کل دیتا را برگشت نده
            int rowsCount = 0;
            var usersList= users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
                IsActive=p.IsActive,
            }).ToList();

            return new ResultGetUserDto
            {
                Rows = rowsCount,
                Users = usersList,
            };
        }
    }
}
