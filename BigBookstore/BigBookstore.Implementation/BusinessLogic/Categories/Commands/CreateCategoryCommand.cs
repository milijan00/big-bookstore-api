using BigBookstore.Application.BusinessLogic.Categories.Commands;
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

namespace BigBookstore.Implementation.BusinessLogic.Categories.Commands
{
    public class CreateCategoryCommand : ICreateCategoryCommand
    {
        public string Name { get; set; }
    }

    public class CreateCategoryCommandHandler : RequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly CreateCategoryValidator validator;

        public CreateCategoryCommandHandler(IApplicationService service, CreateCategoryValidator validator) : base(service)
        {
            this.validator = validator;
        }

        public override async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);
            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            await this.ApplicationService.CreateAsync<Category>(category);
            return new Unit();
        }
    }
}
