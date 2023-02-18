using BigBookstore.Implementation.BusinessLogic.BindingTypes.Commands;
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
    public class UpdateBindingTypeValidator : BaseValidator<UpdateBindingTypeCommand>
    {
        public UpdateBindingTypeValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .Must(x => x.NotEmpty()).WithMessage("BindingType's id is not valid.")
                .Must(id => Context.BindingTypes.Any(x => x.Id == id)).WithMessage("Given BrandingType doesn't exist.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BindingType's name must not be null or empty.")
                .Must(name => !Context.BindingTypes.Any(x => x.Name == name)).WithMessage("Given name is already taken.");
        }
    }
}
