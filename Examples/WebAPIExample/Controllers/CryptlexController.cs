using Cryptlex.Net.Core;
using Cryptlex.Net.Licenses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIExample.Controllers
{
    [ApiController]
    [Route("cryptlex")]
    public class CryptlexController : ControllerBase
    {
        private readonly ICryptlexClient _cryptlexClient;

        public CryptlexController(ICryptlexClient cryptlexClient)
        {
            _cryptlexClient = cryptlexClient;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            Console.WriteLine("Fetching licenses from cryptlex...\n");

            var licenses = await _cryptlexClient.Licenses.ListAsync(new ListLicensesData() { Page = 1 });

            Console.WriteLine($"\nDone! Got {licenses.Count()} licenses from cryptlex: ");
            foreach (var license in licenses) Console.WriteLine(license.Id);
            Console.WriteLine();

            return licenses.Select(license => license.Id!);
        }
    }
}