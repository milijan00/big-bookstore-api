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
    public class UpdateRoleCommand : IUpdateRoleCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateRoleCommandHandler : RequestHandler<UpdateRoleCommand, Unit>
    {
        private readonly UpdateRoleValidator validator;

        public UpdateRoleCommandHandler(IApplicationService service, UpdateRoleValidator validator) : base(service)
        {
            this.validator = validator;
        }

        public override async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);

            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }

            var role = await this.ApplicationService.GetByIdAsync<Role>(request.Id);
            role.Name = request.Name;
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
