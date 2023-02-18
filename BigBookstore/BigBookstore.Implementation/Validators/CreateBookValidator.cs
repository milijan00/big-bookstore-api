using BigBookstore.Implementation.BusinessLogic.Books.Commands;
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
    public class CreateBookValidator : BaseValidator<CreateBookCommand>
    {
        public CreateBookValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Book's title must not be null or empty.")
                .Must(name => !Context.Books.Any(x => x.Name == name)).WithMessage("Given title is already taken.");

            RuleFor(x => x.AuthorId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id.NotEmpty()).WithMessage("Author's id is invalid.")
                .Must(id => Context.Authors.Any(x => x.Id == id && x.IsActive)).WithMessage("Given author doesn't exist");

            RuleFor(x => x.CategoryId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id.NotEmpty()).WithMessage("Category's id is invalid.")
                .Must(id => Context.Categories.Any(x => x.Id == id && x.IsActive)).WithMessage("Given category doesn't exist");

            RuleFor(x => x.LetterId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id.NotEmpty()).WithMessage("Letters's id is invalid.")
                .Must(id => Context.Letters.Any(x => x.Id == id && x.IsActive)).WithMessage("Given letter doesn't exist");

            RuleFor(x => x.BindingTypeId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id.NotEmpty()).WithMessage("Binding type's id is invalid.")
                .Must(id => Context.BindingTypes.Any(x => x.Id == id && x.IsActive)).WithMessage("Given binding type doesn't exist");

            RuleFor(x => x.Pages)
                .Must(pages => pages > 0).WithMessage("Number of pages can't be less than or equal to 0");
        }
    }
}
