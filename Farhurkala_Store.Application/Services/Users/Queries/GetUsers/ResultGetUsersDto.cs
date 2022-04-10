using System.Collections.Generic;

namespace Farhurkala_Store.Application.Services.Users.Queries.GetUsers
{
    //ماباید بدانیم کل رکوردهای توی دیتابیس چندتا هست و براساس اون پیجینیشن را انجام بدیم
    //Dto یعنی حمل کننده دیتا بین لایه ها
    public class ResultGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
