using BigBookstore.Application.BusinessLogic.Letters.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Implementation.Exceptions;
using BigBookstore.Implementation.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Letters.Commands
{
    public class CreateLetterCommand : ICreateLetterCommand
    {
        public string Name { get; set; }
    }
    public class CreateLetterCommandHandler : RequestHandlerWithValidator<CreateLetterCommand, Unit, CreateLetterValidator>
    {
        public CreateLetterCommandHandler(IApplicationService service, CreateLetterValidator validator) : base(service, validator)
        {
        }

        protected override async Task<Unit> ExecuteOperation(CreateLetterCommand request)
        {
            var letter = new Domain.Entities.Letter
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            await this.ApplicationService.CreateAsync(letter);
            return new Unit();
        }
    }
}
