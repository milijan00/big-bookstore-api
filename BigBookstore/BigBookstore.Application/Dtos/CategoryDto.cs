using BigBookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
    }
}
