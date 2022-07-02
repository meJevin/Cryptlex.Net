using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common
{
    public static class Utils
    {
        public static IConfiguration BuildConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets(typeof(Secrets).Assembly)
                .Build();

            return config;
        }
    }
}
