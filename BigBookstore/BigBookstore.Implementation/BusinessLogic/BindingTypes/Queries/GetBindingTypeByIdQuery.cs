using BigBookstore.Application.BusinessLogic.BindingTypes.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.BindingTypes.Queries
{
    public class GetBindingTypeByIdQuery : IGetBindingTypeByIdQuery
    {
        public Guid Id { get; set; }
    }
    public class GetBindingTypeByIdQueryHandler : RequestHandler<GetBindingTypeByIdQuery, BindingTypeDto>
    {
        public GetBindingTypeByIdQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<BindingTypeDto> Handle(GetBindingTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var bindingType = await this.ApplicationService.GetByIdAsync<BindingType>(request.Id);
            if(bindingType == null)
            {
                throw new EntityNotFoundException(nameof(BindingType), request.Id);
            }

            return new BindingTypeDto
            {
                Id = bindingType.Id,
                Name = bindingType.Name
            };
        }
    }
}
