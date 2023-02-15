using BigBookstore.Application.BusinessLogic.Authors.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Authors.Commands
{
    public class DeleteAuthorCommand : IDeleteAuthorCommand
    {
        public Guid Id { get; set; }
    }

    public class DeleteAuthorCommandHandler : RequestHandler<DeleteAuthorCommand, Unit>
    {
        public DeleteAuthorCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await this.ApplicationService.GetByIdAsync<Author>(request.Id);
            if(author == null)
            {
                throw new EntityNotFoundException(nameof(Author), request.Id);
            }
            author.IsActive = false;

            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
