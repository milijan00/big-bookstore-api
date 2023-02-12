using BigBookstore.Application.BusinessLogic.Roles.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Roles.Commands
{
    public class DeleteRoleCommand : IDeleteRoleCommand
    {
        public Guid Id { get; set; }
    }

    public class DeleteRoleCommandHandler : RequestHandler<DeleteRoleCommand, Unit>
    {
        public DeleteRoleCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await this.ApplicationService.DeleteAsync<Role>(request.Id);
            return new Unit();
        }
    }
}
