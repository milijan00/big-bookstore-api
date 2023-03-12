using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Domain.Entities
{
    public class LoggedException
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsSolved { get; set; }
    }
}
