using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string Entity { get; set; }
        public EntityNotFoundException(string entity, object id) : base($"Entity {entity} was not found for {id}")
        {

        }
    }
}
