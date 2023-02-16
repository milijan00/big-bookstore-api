using BigBookstore.Application.BusinessLogic.Letters.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Letters.Queries
{
    public class GetLettersQuery : IGetLettersQuery
    {
    }
    public class GetLettersQueryHandler : RequestHandler<GetLettersQuery, IEnumerable<LetterDto>>
    {
        public GetLettersQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<IEnumerable<LetterDto>> Handle(GetLettersQuery request, CancellationToken cancellationToken)
        {
            return await this.ApplicationService.Entity<Letter>()
                .Where(x => x.IsActive)
                .Select(x => new LetterDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
        }
    }
}
