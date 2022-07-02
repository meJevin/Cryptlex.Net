using Cryptlex.Net.Core;
using Cryptlex.Net.Licenses;
using Microsoft.Extensions.Hosting;

namespace ConsoleAppExample
{
    public class HostedMain : IHostedService
    {
        private readonly ICryptlexClient _cryptlexClient;
        private readonly IHostApplicationLifetime _appLifetime;

        public HostedMain(ICryptlexClient cryptlexClient, IHostApplicationLifetime appLifetime)
        {
            _cryptlexClient = cryptlexClient;
            _appLifetime = appLifetime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Fetching licenses from cryptlex...\n");

            var licenses = await _cryptlexClient.Licenses.ListAsync(new ListLicensesData() { Page = 1 });

            Console.WriteLine($"\nDone! Got {licenses.Count()} licenses from cryptlex: ");
            foreach (var license in licenses) Console.WriteLine(license.Id);
            Console.WriteLine();

            Console.ReadKey();

            _appLifetime.StopApplication();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}
