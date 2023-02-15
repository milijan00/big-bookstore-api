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
    public class UpdateBindingTypeCommand : IUpdateBindingTypeCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateBindingTypeCommandHandler : RequestHandler<UpdateBindingTypeCommand, Unit>
    {
        private readonly UpdateBindingTypeValidator validator;

        public UpdateBindingTypeCommandHandler(IApplicationService service, UpdateBindingTypeValidator validator) : base(service)
        {
            this.validator = validator;
        }

        public override async Task<Unit> Handle(UpdateBindingTypeCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);
            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }

            var bindingType = await this.ApplicationService.GetByIdAsync<BindingType>(request.Id);

            bindingType.Name = request.Name;
            await this.ApplicationService.SaveChangesAsync();

            return new Unit();
        }
    }
}
