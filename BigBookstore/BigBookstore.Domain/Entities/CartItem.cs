using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Domain.Entities
{
    public class CartItem 
    {
        public Book Book { get; set; }
        public Cart Cart { get; set; }
        public Guid BookId { get; set; }
        public Guid CartId { get; set; }
    }
}
