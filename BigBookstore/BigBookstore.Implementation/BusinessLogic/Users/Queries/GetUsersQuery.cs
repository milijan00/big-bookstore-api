using BigBookstore.Application.BusinessLogic.Users.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Users.Queries
{
    public class GetUsersQuery : IGetUsersQuery
    {
    }

    public class GetUsersQueryHandler : RequestHandler<GetUsersQuery, IEnumerable<UserDto>>
    {
        public GetUsersQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<IEnumerable<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await this.ApplicationService.Entity<User>()
                .Where(x => x.IsActive)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    FirstName = x.Firstname,
                    LastName = x.Lastname,
                    Email = x.Email
                }).ToListAsync();
        }
    }
}
