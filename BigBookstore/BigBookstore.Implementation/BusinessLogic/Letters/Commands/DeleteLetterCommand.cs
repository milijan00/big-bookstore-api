using BigBookstore.Application.BusinessLogic.Letters.Commands;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Letters.Commands
{
    public class DeleteLetterCommand : IDeleteLetterCommand
    {
        public Guid Id { get; set; }
    }
    public class DeleteLetterCommandHandler : RequestHandler<DeleteLetterCommand, Unit>
    {
        public DeleteLetterCommandHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<Unit> Handle(DeleteLetterCommand request, CancellationToken cancellationToken)
        {
            var letter = await this.ApplicationService.GetByIdAsync<Letter>(request.Id);

            if(letter == null)
            {
                throw new EntityNotFoundException(nameof(Letter), request.Id);
            }
            letter.IsActive = false;
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
