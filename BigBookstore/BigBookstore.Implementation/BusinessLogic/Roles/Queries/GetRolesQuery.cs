using BigBookstore.Application.BusinessLogic.Roles.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Roles.Queries
{
    public class GetRolesQuery : IGetRolesQuery
    {
    }

    public class GetRolesQueryHandler : RequestHandler<GetRolesQuery, IEnumerable<RoleDto>>
    {
        public GetRolesQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async  Task<IEnumerable<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return await this.ApplicationService.Entity<Role>()
                .Where(x => x.IsActive)
                .Select(x => new RoleDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }
    }
}
