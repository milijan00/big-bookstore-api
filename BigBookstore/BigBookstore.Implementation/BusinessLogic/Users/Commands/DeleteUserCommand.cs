using BigBookstore.Application.BusinessLogic.Users.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Users.Commands
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        public Guid Id { get; set; }
    }

    public class DeleteUserCommandHandler : RequestHandler<DeleteUserCommand, Unit>
    {
        public DeleteUserCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await this.ApplicationService.GetByIdAsync<User>(request.Id);
            if(user == null)
            {
                throw new EntityNotFoundException(nameof(User), request.Id);
            }
            user.IsActive = false;
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
