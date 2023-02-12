using BigBookstore.Application.BusinessLogic.Categories.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Categories.Commands
{
    public class DeleteCategoryCommand : IDeleteCategoryCommand
    {
        public Guid Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : RequestHandler<DeleteCategoryCommand, Unit>
    {
        public DeleteCategoryCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await this.ApplicationService.DeleteAsync<Category>(request.Id);
            return new Unit();
        }
    }
}
