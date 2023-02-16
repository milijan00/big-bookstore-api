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
        public uint Pages { get; set; }
        public ICollection<CartItem> Carts { get; set; } = new List<CartItem>();
        public Letter Letter { get; set; }
        public Guid LetterId { get; set; }
        public string Image { get; set; }
    }
}
