using BigBookstore.Application.BusinessLogic.Letters.Commands;
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

namespace BigBookstore.Implementation.BusinessLogic.Letters.Commands
{
    public class UpdateLetterCommand : IUpdateLetterCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateLetterCommandHandler : RequestHandlerWithValidator<UpdateLetterCommand, Unit, UpdateLetterValidator>
    {
        public UpdateLetterCommandHandler(IApplicationService service, UpdateLetterValidator validator) : base(service, validator)
        {
        }

        protected override async Task<Unit> ExecuteOperation(UpdateLetterCommand request)
        {
            var letter = await this.ApplicationService.GetByIdAsync<Letter>(request.Id);
            letter.Name = request.Name;
            await this.ApplicationService.SaveChangesAsync();
            return new Unit();
        }
    }
}
