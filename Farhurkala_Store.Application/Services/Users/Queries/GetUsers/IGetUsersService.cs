using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Farhurkala_Store.Application.Services.Users.Queries.GetUsers
{
    //سرویس یه قطعه کده که بیزینس لاجیک مارا پیاده سازی می کنه
    public interface IGetUsersService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
}
