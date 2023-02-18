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

    public class UpdateRoleCommandHandler : RequestHandlerWithValidator<UpdateRoleCommand, Unit, UpdateRoleValidator>
    {
        public UpdateRoleCommandHandler(IApplicationService service, UpdateRoleValidator validator) : base(service, validator)
        {
        }
        protected override async  Task<Unit> ExecuteOperation(UpdateRoleCommand request)
        {
            var role = await this.ApplicationService.GetByIdAsync<Role>(request.Id);
            role.Name = request.Name;
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
