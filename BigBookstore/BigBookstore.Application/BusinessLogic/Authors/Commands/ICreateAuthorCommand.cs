using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Authors.Commands
{
    public interface ICreateAuthorCommand : ICommand<Unit>
    {
        public string FullName { get; set; }
    }
}
