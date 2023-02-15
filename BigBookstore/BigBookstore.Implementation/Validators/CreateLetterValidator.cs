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
    public class CreateLetterValidator : BaseValidator<CreateLetterCommand>
    {
        public CreateLetterValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Letter's name must not be null or empty.")
                .Must(name => !Context.Letters.Any(x => x.Name == name)).WithMessage("Given name is already taken.");
        }
    }
}
