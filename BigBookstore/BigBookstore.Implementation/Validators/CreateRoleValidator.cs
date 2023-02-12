using BigBookstore.Implementation.BusinessLogic.Roles.Commands;
using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Validators
{
    public class CreateRoleValidator : BaseValidator<CreateRoleCommand>
    {
        public CreateRoleValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Role's name must not be null or empty.")
                .Must(name => !Context.Roles.Any(x => x.Name == name)).WithMessage("Role's name is already taken.");

        }
    }
}
