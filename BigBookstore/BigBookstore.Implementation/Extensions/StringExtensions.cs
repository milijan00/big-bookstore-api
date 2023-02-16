using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Extensions
{
    public static class StringExtensions
    {
        public static bool NotNullOrEmpty(this string x)
        {
            return !string.IsNullOrEmpty(x);
        }
    }
}
