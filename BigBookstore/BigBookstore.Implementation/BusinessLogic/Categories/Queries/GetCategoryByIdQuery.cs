using BigBookstore.Application.BusinessLogic.Categories.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Categories.Queries
{
    public class GetCategoryByIdQuery : IGetCategoryByIdQuery
    {
        public Guid Id { get; set; }
    }

    public class GetCategoryByIdQueryHandler : RequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        public GetCategoryByIdQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await this.ApplicationService.GetByIdAsync<Category>(request.Id);
            if(category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request.Id);
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
