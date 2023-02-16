using BigBookstore.Application.BusinessLogic.Users.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Enums;
using BigBookstore.Implementation.Exceptions;
using BigBookstore.Implementation.Extensions;
using BigBookstore.Implementation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Users.Commands
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public Guid RoleId { get; set;}
    }

    public class UpdateUserCommandHandler : RequestHandler<UpdateUserCommand, Unit>
    {
        private readonly UpdateUserValidator validator;

        public UpdateUserCommandHandler(IApplicationService service, UpdateUserValidator validator) : base(service)
        {
            this.validator = validator;
        }

        public override async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);
            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }

            var user = await this.ApplicationService.GetByIdAsync<User>(request.Id);
            this.UpdateUsersValues(user, request);
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
        private void UpdateUsersValues(User user, UpdateUserCommand request)
        {
            if(request.FirstName.NotNullOrEmpty() && user.Firstname != request.FirstName)
            {
                user.Firstname = request.FirstName;
            }

            if(request.LastName.NotNullOrEmpty() && user.Lastname != request.LastName)
            {
                user.Lastname = request.LastName;
            }

            if(request.Email.NotNullOrEmpty() && user.Email != request.Email)
            {
                user.Email = request.Email;
            }

            bool passwordsAreDifferent = !BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (request.Password.NotNullOrEmpty() && passwordsAreDifferent)
            {
                const int salt = 10;
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password, salt);
            }
        }
    }
}
