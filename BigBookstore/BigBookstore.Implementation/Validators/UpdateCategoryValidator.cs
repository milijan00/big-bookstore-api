using BigBookstore.Implementation.BusinessLogic.Categories.Commands;
using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Validators
{
    public class UpdateCategoryValidator : BaseValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category's name must not be null or empty.")
                .Must(name => !Context.Categories.Any(x => x.Name == name)).WithMessage("Category's name is already taken.");
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Category's id must not be null or empty")
                .Must(id => Context.Categories.Any(x => x.Id == id)).WithMessage("Given category doesn't exist.");
        }
    }
}
