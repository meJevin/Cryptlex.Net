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
            public static string Me => "me";
            public static string Roles => "roles";

            // Account management
            public static string Accounts => "accounts";

            // Access tokens
            public static string PersonalAccessTokens => "personal-access-tokens";

            // Policies
            public static string LicensePolicies => "license-policies";
            public static string TrialPolicies => "trial-policies";

            // Products
            public static string Products => "products";
            public static string FeatureFlags => "feature-flags";
            public static string ProductVersions => "product-versions";

            // Release management
            public static string Releases => "releases";
            public static string ReleaseFiles => "release-files";

            // License management
            public static string Licenses => "licenses";
            public static string Activations => "activations";
            public static string Tags => "tags";

            // Trials
            public static string TrialActivations => "trial-activations";

            // Email templates
            public static string EmailTemplates = "email-templates";

            // Webhooks
            public static string Webhooks => "webhooks";

        }
    }
}
