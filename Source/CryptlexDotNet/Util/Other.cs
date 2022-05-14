using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptlexDotNet.Util
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

    public static class ObjectExtensions
    {
        public static string ToQueryString(this object obj, bool ignoreNull = true)
        {
            return string.Join("&", obj.GetType()
                                       .GetProperties()
                                       .Where(p => ignoreNull && p.GetValue(obj, null) != null)
                                       .Select(p => $"{Uri.EscapeDataString(p.Name)}={Uri.EscapeDataString(p.GetValue(obj)!.ToString()!)}"));
        }
    }
}
