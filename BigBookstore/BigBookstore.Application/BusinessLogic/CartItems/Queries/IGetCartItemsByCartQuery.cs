using BigBookstore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.CartItems.Queries
{
    public interface IGetCartItemsByCartQuery : IQuery<IEnumerable<CartItemDto>>
    {
    }
}
