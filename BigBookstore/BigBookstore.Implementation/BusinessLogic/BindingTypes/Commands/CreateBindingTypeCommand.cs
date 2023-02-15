using BigBookstore.Application.BusinessLogic.BindingTypes.Commands;
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

namespace BigBookstore.Implementation.BusinessLogic.BindingTypes.Commands
{
    public class CreateBindingTypeCommand : ICreateBindingTypeCommand
    {
        public string Name { get; set; }
    }

    public class CreateBindingTypeCommandHandler : RequestHandler<CreateBindingTypeCommand, Unit>
    {
        private readonly CreateBindingTypeValidator validator;

        public CreateBindingTypeCommandHandler(IApplicationService service, CreateBindingTypeValidator validator) : base(service)
        {
            this.validator = validator;
        }

        public override async Task<Unit> Handle(CreateBindingTypeCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);
            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }

            var bindingType = new BindingType
            {
                Name = request.Name
            };
            await this.ApplicationService.CreateAsync<BindingType>(bindingType);
            return new Unit();
        }
    }
}
