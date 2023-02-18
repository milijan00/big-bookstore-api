using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Letters.Commands
{
    public interface IUpdateLetterCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
