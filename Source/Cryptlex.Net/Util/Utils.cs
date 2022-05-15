using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Util
{
    public static class Utils
    {
        public static string CombinePaths(params string[] paths)
        {
            return string.Join("/", paths);
        }

        public static string AppendQueryString(this string uri, string queryStr)
        {
            if (queryStr is null || queryStr.Length == 0) return uri;

            return uri + "?" + queryStr;
        }
    }
}
