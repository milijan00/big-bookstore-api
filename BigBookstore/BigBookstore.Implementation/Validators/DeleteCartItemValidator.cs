using BigBookstore.Implementation.BusinessLogic.Cartitems.Commands;
using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Validators
{
    public class DeleteCartItemValidator : BaseValidator<DeleteCartItemCommand>
    {
        public DeleteCartItemValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.CartId)
                .Must(id => Context.Carts.Any(x => x.Id == id && x.IsActive)).WithMessage("Given cart doesn't exist.");
            RuleFor(x => x.BookId)
                .Must(id => Context.Books.Any(x => x.Id == id && x.IsActive)).WithMessage("Given book doesn't exist.");
        }
    }
}
