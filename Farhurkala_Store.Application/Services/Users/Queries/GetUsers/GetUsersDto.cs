namespace Farhurkala_Store.Application.Services.Users.Queries.GetUsers
{
    //لیستی از اطلاعاتی که می خوایم به کاربر نشون بدیم
    //Dto یعنی حمل کننده دیتا بین لایه ها
    public class GetUsersDto
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
