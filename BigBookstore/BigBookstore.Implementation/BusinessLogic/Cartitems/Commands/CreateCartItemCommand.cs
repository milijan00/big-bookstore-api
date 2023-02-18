using BigBookstore.Application.BusinessLogic.CartItems.Commands;
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

namespace BigBookstore.Implementation.BusinessLogic.Cartitems.Commands
{
    public class CreateCartItemCommand : ICreateCartItemCommand
    {
        public Guid CartId { get; set; }
        public Guid BookId { get; set; }
        public uint Quantity { get; set; }
    }

    public class CreateCartItemCommandHandler : RequestHandlerWithValidator<CreateCartItemCommand, Unit, CreateCartItemValidator>
    {
        public CreateCartItemCommandHandler(IApplicationService service, CreateCartItemValidator validator) : base(service, validator)
        {
        }

        protected override async Task<Unit> ExecuteOperation(CreateCartItemCommand request)
        {
            var cartItem = new CartItem
            {
                BookId = request.BookId,
                CartId = request.CartId,
                Quantity = request.Quantity
            };
            await this.ApplicationService.Entity<CartItem>().AddAsync(cartItem);
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
