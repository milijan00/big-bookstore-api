using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Fullname { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
