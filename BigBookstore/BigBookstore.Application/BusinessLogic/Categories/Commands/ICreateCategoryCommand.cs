using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Categories.Commands
{
    public interface ICreateCategoryCommand : ICommand<Unit>
    {
        public string Name { get; set; }
    }
}
