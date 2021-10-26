using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smokeball.Utilities
{
    public static class Extension
    {
        public static string ToCsv(this List<int> array)
        {
            return string.Join(",", array);
        }

        public static string ToCsv(this List<string> array)
        {
            return string.Join(",", array);
        }
    }
}
