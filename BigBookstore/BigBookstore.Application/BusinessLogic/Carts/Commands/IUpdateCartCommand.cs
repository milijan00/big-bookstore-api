using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Carts.Commands
{
    public interface IUpdateCartCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
    }
}
