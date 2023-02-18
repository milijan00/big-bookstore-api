using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Validators
{
    public class CreateAuthorValidator : BaseValidator<BusinessLogic.Authors.Commands.CreateAuthorCommand>
    {
        public CreateAuthorValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.FullName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Author's name must not be null or empty.")
                .Must(name => !Context.Authors.Any(x=> x.Fullname == name)).WithMessage("Author's name is already taken.");
        }
    }
}
