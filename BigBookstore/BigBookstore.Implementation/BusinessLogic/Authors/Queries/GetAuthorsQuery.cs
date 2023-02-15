using BigBookstore.Application.BusinessLogic.Authors.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Authors.Queries
{
    public class GetAuthorsQuery : IGetAuthorsQuery
    {
    }
    public class GetAuthorsQueryHandler : RequestHandler<GetAuthorsQuery, IEnumerable<AuthorDto>>
    {
        public GetAuthorsQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<IEnumerable<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await this.ApplicationService.Entity<Author>()
                .Where(x => x.IsActive)
                .Select(x => new AuthorDto
                {
                    Id = x.Id,
                    Name = x.Fullname
                }).ToListAsync();
        }
    }
}
