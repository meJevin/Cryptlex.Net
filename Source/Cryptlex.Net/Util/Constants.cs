using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Util
{
    public static class API
    {
        public static string Version => "v3";
        public static string Address => "https://api.cryptlex.com/";
        public static string AuthenticationScheme => "Bearer";
        public static string MediaType => "application/json";

        public static class Paths
        {
            // User management
            public static string Users => "users";
            public static string Roles => "roles";

            // Account management
            public static string Accounts => "accounts";

            // Access tokens
            public static string PersonalAccessTokens => "personal-access-tokens";

            // License management
            public static string Licenses => "licenses";
            public static string Activations => "activations";
            public static string Tags => "tags";
        }
    }
}
