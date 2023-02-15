using BigBookstore.Application.BusinessLogic.Authors.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Authors.Queries
{
    public class GetAuthorByIdQuery : IGetAuthorByIdQuery
    {
        public Guid Id { get; set; }
    }
    public class GetAuthorByIdQueryHandler : RequestHandler<GetAuthorByIdQuery, AuthorDto>
    {
        public GetAuthorByIdQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await this.ApplicationService.GetByIdAsync<Author>(request.Id);

            if(author == null)
            {
                throw new EntityNotFoundException(nameof(Author), request.Id);
            }
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Fullname
            };
        }
    }
}
