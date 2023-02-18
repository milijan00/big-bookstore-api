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

    public class CreateBindingTypeCommandHandler : RequestHandlerWithValidator<CreateBindingTypeCommand, Unit, CreateBindingTypeValidator>
    {
        public CreateBindingTypeCommandHandler(IApplicationService service, CreateBindingTypeValidator validator) : base(service, validator)
        {
        }
        protected override async Task<Unit> ExecuteOperation(CreateBindingTypeCommand request)
        {
            var bindingType = new BindingType
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            await this.ApplicationService.CreateAsync<BindingType>(bindingType);
            return new Unit();
        }
    }
}
