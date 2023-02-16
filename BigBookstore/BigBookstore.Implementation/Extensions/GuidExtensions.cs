using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Extensions
{
    public static class GuidExtensions
    {
       public static bool NotEmpty(this Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
