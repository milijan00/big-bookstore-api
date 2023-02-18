using BigBookstore.Application.BusinessLogic.Authors.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using BigBookstore.Implementation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Authors.Commands
{
    public class CreateAuthorCommand : ICreateAuthorCommand
    {
        public string FullName { get; set; }
    }
    public class CreateAuthorCommandHandler : RequestHandlerWithValidator<CreateAuthorCommand, Unit, CreateAuthorValidator>
    {
        public CreateAuthorCommandHandler(IApplicationService service, CreateAuthorValidator validator) : base(service, validator)
        {
        }
        protected override async Task<Unit> ExecuteOperation(CreateAuthorCommand request)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                Fullname = request.FullName
            };
            await this.ApplicationService.CreateAsync(author);

            return new Unit();
        }
    }
}
