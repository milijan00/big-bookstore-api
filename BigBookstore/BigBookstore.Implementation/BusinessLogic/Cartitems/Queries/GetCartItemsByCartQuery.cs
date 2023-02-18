using BigBookstore.Application.BusinessLogic.CartItems.Queries;
using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.BusinessLogic.Cartitems.Queries
{
    public class GetCartItemsByCartQuery : IGetCartItemsByCartQuery
    {
        public Guid CartId { get; set; }
    }

    public class GetCartItemsByCartQueryHandler : RequestHandler<GetCartItemsByCartQuery, IEnumerable<CartItemDto>>
    {
        public GetCartItemsByCartQueryHandler(IApplicationService service) : base(service)
        {
        }

        public override async Task<IEnumerable<CartItemDto>> Handle(GetCartItemsByCartQuery request, CancellationToken cancellationToken)
        {
            return await this.ApplicationService.Entity<CartItem>()
                .Include(x => x.Book)
                .Where(x => x.CartId == request.CartId)
                .Select(x => new CartItemDto
                {
                    BookId = x.BookId,
                    BookName = x.Book.Name,
                    Quantity = x.Quantity,
                    CartId = x.CartId,
                    Image = x.Book.Image
                }).ToListAsync();
        }
    }
}
