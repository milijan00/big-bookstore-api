using BigBookstore.Implementation.BusinessLogic.Users.Commands;
using BigBookstore.Implementation.Enums;
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
    public class UpdateUserValidator : BaseValidator<UpdateUserCommand>
    {
        public UpdateUserValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .Must(id => id.NotEmpty()).WithMessage("User's id is invalid.")
                .Must(id => Context.Users.Any(x => x.Id == id)).WithMessage("Given user doesn't exist");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .Must(email => !Context.Users.Any(x => x.Email == email))
                    .WithMessage("Given email is already taken.")
                    .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.RoleId)
                .Must(role => Context.Roles.Any(x => x.Id == role))
                .WithMessage("Given role doesn't exist.")
                .When(x => x.RoleId.NotEmpty());

            RuleFor(x => new { p = x.Password, pa = x.PasswordAgain })
                .Must(o => o.p == o.pa).WithMessage("Both passwords must be equal.");
        }
    }
}
