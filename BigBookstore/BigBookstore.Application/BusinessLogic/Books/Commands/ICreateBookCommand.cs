using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.BusinessLogic.Books.Commands
{
    public interface ICreateBookCommand : ICommand<Unit>
    {
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LetterId { get; set; }
        public Guid BindingTypeId { get; set; }
        public uint Pages { get; set; }
        public string Image { get; set; }
    }
}
