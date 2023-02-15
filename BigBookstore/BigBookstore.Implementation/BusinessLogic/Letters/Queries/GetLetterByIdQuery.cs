using BigBookstore.Application.BusinessLogic.Letters.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Letters.Queries
{
    public class GetLetterByIdQuery : IGetLetterByIdQuery
    {
        public Guid Id { get; set; }
    }

    public class GetLetterByIdQueryHandler : RequestHandler<GetLetterByIdQuery, LetterDto>
    {
        public GetLetterByIdQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<LetterDto> Handle(GetLetterByIdQuery request, CancellationToken cancellationToken)
        {
            var letter = await this.ApplicationService.GetByIdAsync<Letter>(request.Id);

            if(letter == null)
            {
                throw new EntityNotFoundException(nameof(Letter), request.Id);
            }

            return new LetterDto
            {
                Id = letter.Id,
                Name = letter.Name
            };
        }
    }
}
