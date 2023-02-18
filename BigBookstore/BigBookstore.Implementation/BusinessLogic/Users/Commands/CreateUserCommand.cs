using BigBookstore.Application.BusinessLogic.Users.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Enums;
using BigBookstore.Implementation.Exceptions;
using BigBookstore.Implementation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Users.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }

    public class CreateUserCommandHandler : RequestHandlerWithValidator<CreateUserCommand, Unit, CreateUserValidator>
    {
        public CreateUserCommandHandler(IApplicationService service, CreateUserValidator validator) : base(service, validator)
        {
        }
        protected override async Task<Unit> ExecuteOperation(CreateUserCommand request)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Firstname = request.FirstName,
                Lastname = request.LastName,
                Email = request.Email,
                RoleId = Guid.Empty // change this to RegularUser role id once it's created
            };
            await this.ApplicationService.CreateAsync(user);
            return new Unit();
        }
    }
}
