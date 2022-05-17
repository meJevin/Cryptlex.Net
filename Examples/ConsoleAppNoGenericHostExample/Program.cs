using Cryptlex.Net.Core;
using Cryptlex.Net.Licenses;

var cryptlexClientSettings = new CryptlexClientSettings() { AccessToken = "YOUR_TOKEN" };

var cryptlexClient = CryptlexClientFactory.Create(cryptlexClientSettings);

Console.WriteLine("Fetching licenses from cryptlex...\n");

var licenses = await cryptlexClient.Licenses.ListAsync(new ListLicensesData() { page = 1 });

Console.WriteLine($"\nDone! Got {licenses.Count()} licenses from cryptlex: ");
foreach (var license in licenses) Console.WriteLine(license.id);
Console.WriteLine();

Console.ReadKey();