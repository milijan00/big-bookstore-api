using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Domain.Entities
{
    public class RoleUsecase  
    {
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
        public Usecase Usecase { get; set; }
        public Guid UsecaseId { get; set; }
    }
}
