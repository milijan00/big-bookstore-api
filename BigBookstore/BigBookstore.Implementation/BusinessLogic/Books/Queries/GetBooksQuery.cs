using BigBookstore.Application.BusinessLogic.Books.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Books.Queries
{
    public class GetBooksQuery : IGetBooksQuery
    {
    }
    public class GetBooksQueryHandler : RequestHandler<GetBooksQuery, IEnumerable<BookDto>>
    {
        public GetBooksQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async  Task<IEnumerable<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await this.ApplicationService.Entity<Book>()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Letter)
                .Include(x => x.BindingType)
                .Where(x => x.IsActive)
                .Select(x => new BookDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Author = x.Author.Fullname,
                    Letter = x.Letter.Name,
                    Category = x.Category.Name,
                    BindingType = x.BindingType.Name,
                    Image = x.Image,
                    Pages = x.Pages
                }).ToListAsync();
        }
    }
}
