using BigBookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.Dtos
{
    public class CartDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string Address { get; set; }
    }
}
