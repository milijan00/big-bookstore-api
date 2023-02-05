using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BigBookstore.Application.BusinessLogic.BindingTypes.Commands
{
    public interface ICreateBindingTypeCommand : ICommand<Unit>
    {
    }
}
