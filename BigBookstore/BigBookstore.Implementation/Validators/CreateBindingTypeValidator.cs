using BigBookstore.Implementation.BusinessLogic.BindingTypes.Commands;
using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Validators
{
    public class CreateBindingTypeValidator : BaseValidator<CreateBindingTypeCommand>
    {
        public CreateBindingTypeValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BindingType's name must not be null or empty.")
                .Must(name => !Context.BindingTypes.Any(x => x.Name == name)).WithMessage("Given name is already taken.");
        }
    }
}
