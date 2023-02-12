using BigBookstore.Application.BusinessLogic.Categories.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Categories.Queries
{
    public class GetCategoriesQuery : IGetCategoriesQuery
    {
    }

    public class GetCategoriesQueryHandler : RequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public GetCategoriesQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async  Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await this.ApplicationService.Entity<Category>()
                .Where(x => x.IsActive)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }
    }
}
