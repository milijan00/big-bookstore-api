using BigBookstore.Implementation.BusinessLogic.Books.Commands;
using BigBookstore.Implementation.Extensions;
using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Validators
{
    public class UpdateBookValidator : BaseValidator<UpdateBookCommand>
    {
        public UpdateBookValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .Must(id => id != Guid.Empty).WithMessage("Book's id is invalid")
                .Must(id => Context.Books.Any(x => x.Id == id)).WithMessage("Given book doesn't exist");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .Must(name => Context.Books.Any(x => x.Name == name))
                .WithMessage("Given title is already taken.")
                .When(x => x.Name.NotNullOrEmpty());

            RuleFor(x => x.AuthorId)
                .Cascade(CascadeMode.Stop)
                .Must(id => Context.Authors.Any(x => x.Id == id))
                .WithMessage("Given author doesn't exist")
                .When(x => x.AuthorId != Guid.Empty);

            RuleFor(x => x.CategoryId)
                .Cascade(CascadeMode.Stop)
                .Must(id => Context.Categories.Any(x => x.Id == id))
                .WithMessage("Given category doesn't exist")
                .When(x => x.CategoryId != Guid.Empty);

            RuleFor(x => x.LetterId)
                .Cascade(CascadeMode.Stop)
                .Must(id => Context.Letters.Any(x => x.Id == id))
                .WithMessage("Given letter doesn't exist")
                .When(x => x.LetterId != Guid.Empty);

            RuleFor(x => x.BindingTypeId)
                .Cascade(CascadeMode.Stop)
                .Must(id => Context.BindingTypes.Any(x => x.Id == id))
                .WithMessage("Given binding type doesn't exist")
                .When(x => x.BindingTypeId != Guid.Empty);
        }
    }
}
