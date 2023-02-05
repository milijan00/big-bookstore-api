using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.Dtos
{
    public class BookDto : BaseDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Letter { get; set; }
        public string BindingType { get; set; }
        public string Category { get; set; }
        public uint Pages { get; set; }

    }
}
