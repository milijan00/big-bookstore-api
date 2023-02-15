using BigBookstore.Application.BusinessLogic.BindingTypes.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.BindingTypes.Queries
{
    public class GetBindingTypesQuery : IGetBindingTypesQuery
    {
    }
    public class GetBindingTypesQueryHandler : RequestHandler<GetBindingTypesQuery, IEnumerable<BindingTypeDto>>
    {
        public GetBindingTypesQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<IEnumerable<BindingTypeDto>> Handle(GetBindingTypesQuery request, CancellationToken cancellationToken)
        {
            return await this.ApplicationService.Entity<BindingType>()
                .Where(x => x.IsActive)
                .Select(x => new BindingTypeDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }
    }
}
