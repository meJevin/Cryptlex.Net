using CryptlexDotNet.Core;
using CryptlexDotNet.DTOs.Licenses;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var licenses = await _cryptlexClient.Licenses.ListAll(new ListAllData() { page = 1 });

            Console.WriteLine($"\nDone! Got {licenses.Count()} licenses from cryptlex: ");
            foreach (var license in licenses) Console.WriteLine(license.id);
            Console.WriteLine();

            Console.ReadKey();

            _appLifetime.StopApplication();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}
