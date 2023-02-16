using BigBookstore.Application.BusinessLogic.Carts.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Carts.Commands
{
    public class CreateCartCommand : ICreateCartCommand
    {
        public Guid UserId { get; set; }
    }

    public class CreateCartCommandHandler : RequestHandler<CreateCartCommand, Unit>
    {
        public CreateCartCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<Unit> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var user = await this.ApplicationService.GetByIdAsync<User>(request.UserId);

            if(user == null)
            {
                throw new EntityNotFoundException(nameof(User), request.UserId);
            }

            user.Carts.Add(new Cart
            {
                UserId = user.Id,
                Id = Guid.NewGuid()
            });
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }

}
