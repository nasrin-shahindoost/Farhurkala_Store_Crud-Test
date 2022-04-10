using Farhurkala_Store.Common.Dto;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farhurkala_Store.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        //استفاده از کلاس استفاده شده در dto<T>
        //برای پاس دادن id
        //,بعد از تعریف ورودی ها آن را به ورودی execute می دهیم
        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }
}
