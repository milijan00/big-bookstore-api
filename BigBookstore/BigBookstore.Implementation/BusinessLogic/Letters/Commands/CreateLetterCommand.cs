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
    public class CreateLetterCommandHandler : RequestHandler<CreateLetterCommand, Unit>
    {
        private readonly CreateLetterValidator validator;

        public CreateLetterCommandHandler(IApplicationService service, CreateLetterValidator validator) : base(service)
        {
            this.validator = validator;
        }

        public override async Task<Unit> Handle(CreateLetterCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);

            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }
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
