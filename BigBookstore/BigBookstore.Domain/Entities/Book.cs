using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public BindingType BindingType { get; set; }
        public Guid BindingTypeId { get; set; }
        public uint pages { get; set; }
        public ICollection<CartItem> Charts { get; set; } = new List<CartItem>();
    }
}
