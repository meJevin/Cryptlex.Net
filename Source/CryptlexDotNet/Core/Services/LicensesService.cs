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
        #region LICENSES
        Task<IEnumerable<License>> ListAll(ListAllData data);
        //Task<License> CreateLicenseAsync();
        //Task<License> GetLicenseAsync();
        //Task<License> UpdateLicenseAsync();
        //Task<License> ExtendLicenseAsync();
        #endregion
    }

    public class LicensesService : BaseService, ILicensesService
    {
        public LicensesService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings) 
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<License>> ListAll(ListAllData data)
        {
            using var client = GetCryptlexClient();

            var uri = UriHelper.CombinePaths(API.Version, API.Paths.Licenses);
            var queryStr = data.ToQueryString();

            var res = await client.GetAsync(uri.AddQueryString(queryStr));

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not get licenses from cryptlex. Error message: {error.message}", error);
            }

            var resStr = await res.Content.ReadAsStringAsync();
            var resObject = JsonSerializer.Deserialize<IEnumerable<License>>(resStr)!;

            return resObject;
        }
    }
}
