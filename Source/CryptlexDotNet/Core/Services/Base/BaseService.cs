using CryptlexDotNet.Entities;
using CryptlexDotNet.Util;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;

namespace CryptlexDotNet.Core.Services
{
    public abstract class BaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly CryptlexClientSettings _cryptlexSettings;

        protected abstract string BasePath { get; }

        public BaseService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings)
        {
            _httpClientFactory = httpClientFactory;
            _cryptlexSettings = cryptlexSettings.Value;
        }

        protected virtual HttpClient GetCryptlexClient()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(API.Address);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                API.AuthenticationScheme, _cryptlexSettings.AccessToken);

            return client;
        }

        protected virtual async Task<Error> ReadCryptlexErrorAsync(HttpContent content)
        {
            try
            {
                return JsonSerializer.Deserialize<Error>(await content.ReadAsStringAsync())!;
            }
            catch
            {
                return new Error() { message = "N/A" };
            }
        }
    }
}
