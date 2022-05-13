using CryptlexDotNet.DTOs.Licenses;
using CryptlexDotNet.Entities;
using CryptlexDotNet.Exceptions;
using CryptlexDotNet.Util;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptlexDotNet.Core.Services
{
    public interface ILicensesService
    {
        Task<IEnumerable<License>> ListAll(ListAllData data);
        Task<License> CreateAsync(CreateData data);
        //Task<License> GetLicenseAsync();
        //Task<License> UpdateLicenseAsync();
        //Task<License> ExtendLicenseAsync();
    }

    public class LicensesService : BaseService, ILicensesService
    {
        public string UriPath => UriHelper.CombinePaths(API.Version, API.Paths.Licenses);

        public LicensesService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings) 
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<License>> ListAll(ListAllData data)
        {
            using var client = GetCryptlexClient();

            var path = UriPath;
            var queryStr = data.ToQueryString();

            var res = await client.GetAsync(path.AddQueryString(queryStr));

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not get licenses from cryptlex. Error message: {error.message}", error);
            }

            var resStr = await res.Content.ReadAsStringAsync();
            var resObject = JsonSerializer.Deserialize<IEnumerable<License>>(resStr)!;

            return resObject;
        }

        public async Task<License> CreateAsync(CreateData data)
        {
            using var client = GetCryptlexClient();

            var path = UriPath;

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(path, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not create license in cryptlex. Error message: {error.message}");
            }

            var resObject = JsonSerializer.Deserialize<License>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }
    }
}
