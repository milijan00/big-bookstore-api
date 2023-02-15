using BigBookstore.Application.BusinessLogic.BindingTypes.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.BindingTypes.Commands
{
    public class DeleteBindingTypeCommand : IDeleteBindingTypeCommand
    {
        public Guid Id { get; set; }
    }

    public class DeleteBindingTypeCommandHandler : RequestHandler<DeleteBindingTypeCommand, Unit>
    {
        public DeleteBindingTypeCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<Unit> Handle(DeleteBindingTypeCommand request, CancellationToken cancellationToken)
        {
            var bindingType = await this.ApplicationService.GetByIdAsync<BindingType>(request.Id);

            if(bindingType == null)
            {
                throw new EntityNotFoundException(nameof(BindingType), request.Id);
            }

            bindingType.IsActive = false;
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
