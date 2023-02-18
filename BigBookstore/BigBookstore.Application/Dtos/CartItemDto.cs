using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.Dtos
{
    public class CartItemDto
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string Image { get; set; }
        public uint Quantity { get; set; }
        public Guid CartId { get; set; }
    }
}
