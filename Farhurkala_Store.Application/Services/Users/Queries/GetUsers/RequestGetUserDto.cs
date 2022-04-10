namespace Farhurkala_Store.Application.Services.Users.Queries.GetUsers
{
    //برای اینکه کدنویسی تمیزی داشته باشیم می آییم و تمام پارامترهای ورودی را در یک کلاس میزاریم
    //چون اگر بیشتر بشه نمی شه همه را پارامتر ورودی بدیم و کدنویسی کثیف میشه
    //Dto یعنی حمل کننده دیتا بین لایه ها
    public class RequestGetUserDto
    {
        public string SearchKey { get; set; }

        public int Page { get; set; }
    }
}
