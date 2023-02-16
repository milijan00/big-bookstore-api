using BigBookstore.Application.BusinessLogic.Carts.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using BigBookstore.Implementation.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Carts.Commands
{
    public class UpdateCartCommand : IUpdateCartCommand
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
    }

    public class UpdateCartCommandHandler : RequestHandler<UpdateCartCommand, Unit>
    {
        public UpdateCartCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<Unit> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await this.ApplicationService.GetByIdAsync<Cart>(request.Id);

            if(cart == null)
            {
                throw new EntityNotFoundException(nameof(Cart), request.Id);
            }
            if (request.Address.NotNullOrEmpty())
            {
                cart.Address = request.Address;
                cart.IsActive = false;
                await this.ApplicationService.SaveChangesAsync();
            }
            return new Unit();
            
        }
    }
}
