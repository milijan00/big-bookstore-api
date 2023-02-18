using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Roles.Commands
{
    public interface ICreateRoleCommand : ICommand<Unit>
    {
        public string Name { get; set; }
    }
}
