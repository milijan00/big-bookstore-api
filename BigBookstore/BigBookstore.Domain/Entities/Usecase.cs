using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Domain.Entities
{
    public  class Usecase : BaseEntity
    { 
        public string Name { get; set; }
        public ICollection<RoleUsecase> Roles { get; set; } = new List<RoleUsecase>();
    }
}
