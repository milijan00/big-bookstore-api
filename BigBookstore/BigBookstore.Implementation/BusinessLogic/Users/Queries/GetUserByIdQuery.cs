using BigBookstore.Application.BusinessLogic.Users.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Users.Queries
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        public Guid Id { get; set; }
    }

    public class GetUserByIdQueryHandler : RequestHandler<GetUserByIdQuery, UserDto>
    {
        public GetUserByIdQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await this.ApplicationService.GetByIdAsync<User>(request.Id);
            if(user == null)
            {
                throw new EntityNotFoundException(nameof(User), request.Id);
            }

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.Firstname,
                LastName = user.Lastname,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }
    }
}
