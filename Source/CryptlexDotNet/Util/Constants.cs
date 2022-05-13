using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Util
{
    public static class API
    {
        public static string Version => "v3";
        public static string Address => "https://api.cryptlex.com/";
        public static string AuthenticationScheme => "Bearer";
        public static string MediaType => "application/json";

        public static class Paths
        {
            public static string Licenses => "licenses";
        }
    }
}
