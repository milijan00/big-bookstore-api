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
    public class DeleteCartCommand : IDeleteCartCommand
    {
        public Guid Id { get; set; }
    }

    public class DeleteCartCommandHandler : RequestHandler<DeleteCartCommand, Unit>
    {
        public DeleteCartCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async  Task<Unit> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await this.ApplicationService.GetByIdAsync<Cart>(request.Id);

            if(cart == null)
            {
                throw new EntityNotFoundException(nameof(Cart), request.Id);
            }
            cart.IsActive = false;
            cart.Books.Clear();
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
