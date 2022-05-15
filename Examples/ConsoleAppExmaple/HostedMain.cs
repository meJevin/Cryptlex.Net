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
using Cryptlex.Net.PersonalAccessTokens;
using Cryptlex.Net.Users;
using Cryptlex.Net.Users.Current;

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
            await Playground();

            Console.WriteLine("Fetching licenses from cryptlex...\n");

            var licenses = await _cryptlexClient.Licenses.ListAsync(new GetAllLicensesData() { page = 1 });

            Console.WriteLine($"\nDone! Got {licenses.Count()} licenses from cryptlex: ");
            foreach (var license in licenses) Console.WriteLine(license.id);
            Console.WriteLine();

            Console.ReadKey();

            _appLifetime.StopApplication();
        }

        public async Task Playground()
        {
            var users = await _cryptlexClient.UserService.Current.GetAllActivateionsAsync(new GetAllCurrentUserActivationsData() { page = 1 });
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}
