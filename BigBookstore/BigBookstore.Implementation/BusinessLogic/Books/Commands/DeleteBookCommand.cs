using BigBookstore.Application.BusinessLogic.Books.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Books.Commands
{
    public class DeleteBookCommand : IDeleteBookCommand
    {
        public Guid Id { get; set; }
    }

    public class DeleteBookCommandHandler : RequestHandler<DeleteBookCommand, Unit>
    {
        public DeleteBookCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await this.ApplicationService.GetByIdAsync<Book>(request.Id);
            if(book == null)
            {
                throw new EntityNotFoundException(nameof(Book), request.Id);
            }
            book.IsActive = false;
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
