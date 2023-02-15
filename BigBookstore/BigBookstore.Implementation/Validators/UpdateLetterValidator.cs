using BigBookstore.Implementation.BusinessLogic.Letters.Commands;
using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Validators
{
    public class UpdateLetterValidator : BaseValidator<UpdateLetterCommand>
    {
        public UpdateLetterValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .Must(id => id != Guid.Empty).WithMessage("Letter's id is invalid.")
                .Must(id => Context.Letters.Any(x => x.Id == id)).WithMessage("Given letter doens't exist.");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Letter's name must not be null or empty.")
                .Must(name => !Context.Letters.Any(x => x.Name == name)).WithMessage("Given name is already taken.");
        }
    }
}
