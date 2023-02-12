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
    public class UpdateRoleValidator : BaseValidator<UpdateRoleCommand>
    {
        public UpdateRoleValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Role's name must not be null or empty.")
                .Must(name => !Context.Roles.Any(x => x.Name == name)).WithMessage("Role's name is already taken.");

            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Role's id must not be null or empty")
                .Must(id => Context.Roles.Any(x => x.Id == id)).WithMessage("Given role doesn't exist.");
        }
    }
}
