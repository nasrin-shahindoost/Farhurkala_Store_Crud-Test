namespace Farhurkala_Store.Application.Services.Users.Commands.RegisterUser
{
    //سرویس ما سه تا خروجی باید به ما برگردونه
    //پس یک dto می خواهیم با سه تا فیلد
    //یکی آی دی کاربری که ثبت نام کرده 
    //یکی یه متغیر بولین که ثبت نام موفقیت آمیز بوده
    //و یکی یه پیغام که ثبت نام با موفقیت انجام شد.
    public class ResultRegisterUserDto
    {
        public long UserId { get; set; }
      
    }
}
