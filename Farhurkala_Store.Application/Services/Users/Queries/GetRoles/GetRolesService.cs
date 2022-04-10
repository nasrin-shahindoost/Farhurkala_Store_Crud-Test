using Farhurkala_Store.Application.Interfaces.Contexts;
using Farhurkala_Store.Common.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Farhurkala_Store.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;

        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetRolesDto>> Execute()
        {
            var roles = _context.Roles.ToList().Select(p => new GetRolesDto
            {
                Id = p.Id,
                Name = p.Name
            }).ToList();

            return new ResultDto<List<GetRolesDto>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
