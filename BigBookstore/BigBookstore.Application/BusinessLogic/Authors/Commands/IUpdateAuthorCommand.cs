using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Authors.Commands
{
    public interface IUpdateAuthorCommand : ICommand<Unit>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
