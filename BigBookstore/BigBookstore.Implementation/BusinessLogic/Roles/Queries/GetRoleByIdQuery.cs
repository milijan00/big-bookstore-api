using BigBookstore.Application.BusinessLogic.Roles.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Roles.Queries
{
    public class GetRoleByIdQuery : IGetRoleByIdQuery
    {
        public Guid Id { get; set; }
    }

    public class GetRoleByIdQueryHandler : RequestHandler<GetRoleByIdQuery, RoleDto>
    {
        public GetRoleByIdQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await this.ApplicationService.GetByIdAsync<Role>(request.Id);
            if(role == null)
            {
                throw new EntityNotFoundException(nameof(Role), request.Id);
            }
            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
