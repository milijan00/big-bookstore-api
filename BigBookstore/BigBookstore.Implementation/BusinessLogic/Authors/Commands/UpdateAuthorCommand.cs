using BigBookstore.Application.BusinessLogic.Authors.Commands;
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

namespace BigBookstore.Implementation.BusinessLogic.Authors.Commands
{
    public class UpdateAuthorCommand : IUpdateAuthorCommand
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }

    public class UpdateAuthorCommandHandler : RequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly UpdateAuthorValidator validator;

        public UpdateAuthorCommandHandler(IApplicationService service, UpdateAuthorValidator validator) : base(service)
        {
            this.validator = validator;
        }

        public override async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var result = this.validator.Validate(request);
            if (!result.IsValid)
            {
                throw new UnprocessableEntityException(result.Errors);
            }

            var author = await this.ApplicationService.GetByIdAsync<Author>(request.Id);
            author.Fullname = request.FullName;
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
