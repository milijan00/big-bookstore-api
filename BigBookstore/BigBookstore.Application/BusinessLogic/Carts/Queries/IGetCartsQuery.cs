using BigBookstore.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Carts.Queries
{
    public interface IGetCartsQuery : IQuery<IEnumerable<CartDto>>
    {
    }
}
