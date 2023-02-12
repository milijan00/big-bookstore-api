using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Exceptions
{
    public  class DbSetNotFoundException : Exception
    {
        public string Entity { get; set; }
        public string Message { get; set; }
        public DbSetNotFoundException(string message, string entity) : base(message)
        {
            this.Entity = entity;
            this.Message = message;
        }
    }
}
