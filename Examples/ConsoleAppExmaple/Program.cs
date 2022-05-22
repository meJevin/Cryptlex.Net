using Cryptlex.Net.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleAppExample
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var builder = Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.AddUserSecrets<Program>(false);
                    })
                    .ConfigureServices((hostContext, services) =>
                    {
                        var config = hostContext.Configuration;

                        //services.AddCryptlexClient(options => options.AccessToken = "YOUR_TOKEN");
                        services.AddCryptlexClient(cfg =>
                        {
                            cfg.WithSettings(options => options.AccessToken = config["CryptlexPersonalAccessToken"]);
                        });

                        services.AddSingleton<HostedMain>();
                        services.AddHostedService(provider => provider.GetService<HostedMain>());
                    });

                await builder.RunConsoleAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nCritical error!\n\n");
                Console.WriteLine(ex.Message);
            }
        }
    }
}