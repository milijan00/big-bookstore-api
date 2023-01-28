using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Domain.Entities
{
    public class Checkout
    {
        public Cart Cart { get; set; }

        public string Address { get; set; }
    }
}
