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
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddCryptlexClient(options => options.AccessToken = "YOUR_TOKEN");

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