using BigBookstore.Application.BusinessLogic.Books.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Books.Queries
{
    public class GetBookByIdQuery : IGetBookByIdQuery
    {
        public Guid Id { get; set; }
    }

    public class GetBookByIdQueryHandler : RequestHandler<GetBookByIdQuery, BookDto>
    {
        public GetBookByIdQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await this.ApplicationService.Entity<Book>()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Letter)
                .Include(x => x.BindingType)
                .FirstOrDefaultAsync(x => x.IsActive && x.Id == request.Id);

            if(book == null)
            {
                throw new EntityNotFoundException(nameof(Book), request.Id);
            }

            return new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author.Fullname,
                Letter = book.Letter.Name,
                Category = book.Category.Name,
                BindingType = book.BindingType.Name,
                Image = book.Image,
                Pages = book.Pages
            };
        }
    }
}
