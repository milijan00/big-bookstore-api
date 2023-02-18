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

    public class CreateCategoryCommandHandler : RequestHandlerWithValidator<CreateCategoryCommand, Unit, CreateCategoryValidator>
    {
        public CreateCategoryCommandHandler(IApplicationService service, CreateCategoryValidator validator) : base(service, validator)
        {
        }

        protected override async Task<Unit> ExecuteOperation(CreateCategoryCommand request)
        {
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
