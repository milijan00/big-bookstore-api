using BigBookstore.Implementation.BusinessLogic.Users.Commands;
using BigBookstore.Implementation.Enums;
using BigBookstore.Persistance;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Validators
{
    public class CreateUserValidator : BaseValidator<CreateUserCommand>
    {
        public CreateUserValidator(BigBookStoreDbContext context) : base(context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name must not be null or empty");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name must not be null or empty");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Last name must not be null or empty")
                .Must(email => !Context.Users.Any(x => x.Email == email)).WithMessage("Given email is already taken.");
            
            RuleFor(x => new { p = x.Password, pa = x.PasswordAgain })
                .Must(o => o.p == o.pa).WithMessage("Both passwords must be equal.");

        }
    }
}
