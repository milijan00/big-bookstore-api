using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.CartItems.Commands
{
    public interface ICreateCartItemCommand : ICommand<Unit>
    {
        public Guid CartId { get; set; }
        public Guid BookId { get; set; }
        public uint Quantity { get; set; }
    }
}
