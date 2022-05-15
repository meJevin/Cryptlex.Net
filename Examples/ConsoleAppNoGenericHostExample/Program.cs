using Cryptlex.Net.Licenses;

var _cryptlexClient = CryptlexClientFactory.Create();

Console.WriteLine("Fetching licenses from cryptlex...\n");

var licenses = await _cryptlexClient.Licenses.ListAsync(new GetAllLicensesData() { page = 1 });

Console.WriteLine($"\nDone! Got {licenses.Count()} licenses from cryptlex: ");
foreach (var license in licenses) Console.WriteLine(license.id);
Console.WriteLine();

Console.ReadKey();