using BigBookstore.Application.BusinessLogic;
using BigBookstore.Application.BusinessLogic.Roles.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using BigBookstore.Implementation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Roles.Commands
{
    public class CreateRoleCommand : ICreateRoleCommand
    {
        public string Name { get; set; }
    }

    public class CreateRoleCommandHandler : RequestHandler<CreateRoleCommand, Unit>
    {
        private readonly CreateRoleValidator validator;

        public CreateRoleCommandHandler(IApplicationService service, CreateRoleValidator validator) : base(service)
        {
            this.validator = validator;
        }

        public override async  Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            await this.ApplicationService.CreateAsync(role);
            return new Unit();
            
        }
    }
}
