using Cryptlex.Net.Core;
using Cryptlex.Net.Factories;
using Cryptlex.Net.Licenses;

var cryptlexClientSettings = new CryptlexClientSettings() { AccessToken = "YOUR_TOKEN" };

var cryptlexClient = CryptlexClientFactory.Create(cryptlexClientSettings);

Console.WriteLine("Fetching licenses from cryptlex...\n");

var licenses = await cryptlexClient.Licenses.ListAsync(new ListLicensesData() { Page = 56 });

Console.WriteLine($"\nDone! Got {licenses.Count()} licenses from cryptlex: ");
foreach (var license in licenses) Console.WriteLine(license.Id);
Console.WriteLine();

Console.ReadKey();