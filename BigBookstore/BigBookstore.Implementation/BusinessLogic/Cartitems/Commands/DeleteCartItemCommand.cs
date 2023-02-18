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
    public class DeleteCartItemCommand : IDeleteCartItemCommand
    {
        public Guid CartId { get; set; }
        public Guid BookId { get; set; }
    }

    public class DeleteCartItemCommandHandler : RequestHandler<DeleteCartItemCommand, Unit>
    {
        private readonly DeleteCartItemValidator validator;

        public DeleteCartItemCommandHandler(IApplicationService service, DeleteCartItemValidator validator) : base(service)
        {
            this.validator = validator;
        }

        public override async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);
            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }
            var cartItem = this.ApplicationService.Entity<CartItem>().First(x => x.CartId == request.CartId && x.BookId == request.BookId);
            this.ApplicationService.Entity<CartItem>().Remove(cartItem);
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
