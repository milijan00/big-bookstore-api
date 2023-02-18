using BigBookstore.Implementation.BusinessLogic.Cartitems.Commands;
using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigBookstore.Implementation.Extensions;

namespace BigBookstore.Implementation.Validators
{
    public class CreateCartItemValidator : BaseValidator<CreateCartItemCommand>
    {
        public CreateCartItemValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.CartId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id.NotEmpty()).WithMessage("CartId is invalid.")
                .Must(id => Context.Carts.Any(x => x.Id == id && x.IsActive)).WithMessage("Given cart doesn't exist.");

            RuleFor(x => x.BookId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id.NotEmpty()).WithMessage("BookId is invalid.")
                .Must(id => Context.Books.Any(x => x.Id == id && x.IsActive)).WithMessage("Given book doesn't exist.");
            RuleFor(x => x.Quantity)
                .Must(q => q > 0).WithMessage("Quantity must not be less than or equal to zero.");
        }
    }
}
