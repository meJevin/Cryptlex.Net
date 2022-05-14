using Cryptlex.Net.Core;
using Cryptlex.Net.Licenses;
using Cryptlex.Net.Activations;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptlex.Net.Tags;

namespace ConsoleAppExample
{
    public class TestClass
    {
        private readonly ICryptlexClient _cryptlexClient;

        public TestClass(ICryptlexClient cryptlexClient)
        {
            _cryptlexClient = cryptlexClient;
        }

        public async Task SomeMethod()
        {
            await _cryptlexClient.Activations.GetAllAsync(new GetAllActivationsData() { page = 2 });
        }
    }

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

            var licenses = await _cryptlexClient.Licenses.GetAllAsync(new GetAllLicensesData() { page = 1 });

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
