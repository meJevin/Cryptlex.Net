using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Util;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Cryptlex.Net.Core.Services
{
    public abstract class BaseService<T> where T : class
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

        #region CRUD
        protected virtual async Task<IEnumerable<T>> GenericGetAllAsync<Req>(Req data, string customUri = null!) where Req : class
        {
            return await GenericGetAllAsync<T, Req>(data);
        }

        protected virtual async Task<IEnumerable<ReturnType>> GenericGetAllAsync<ReturnType, Req>(Req data, string customUri = null!) 
            where Req : class where ReturnType : class
        {
            using var client = GetCryptlexClient();

            var uri = customUri is null ? BasePath : customUri;
            var queryStr = data.ToQueryString();

            var res = await client.GetAsync(uri.AppendQueryString(queryStr));

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"GetAll operation failed for path {uri}. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<IEnumerable<ReturnType>>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        protected virtual async Task<T> GenericCreateAsync<Req>(Req data)
        {
            using var client = GetCryptlexClient();

            var uri = BasePath;

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Create failed for path {uri}. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<T>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        protected virtual async Task<T> GenericGetAsync(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id);
            var res = await client.GetAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Get failed for path {uri}. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<T>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        protected virtual async Task<T> GenericUpdateAsync<Req>(
            string id, Req data, bool usePutHttpMethod = false, 
            string? putFieldName = null)
        {
            using var client = GetCryptlexClient();

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var uri = (usePutHttpMethod && !string.IsNullOrEmpty(putFieldName)) ? 
                Utils.CombinePaths(BasePath, id, putFieldName) : 
                Utils.CombinePaths(BasePath, id);

            var res = usePutHttpMethod ? 
                await client.PatchAsync(uri, content) : 
                await client.PutAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Update failed for path {uri}. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<T>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        protected virtual async Task GenericDeleteAsync(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id);
            var res = await client.DeleteAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Delete failed for path {uri}. Error message: {error.message}", error);
            }
        }
        #endregion

        #region HELPERS
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
        #endregion
    }
}
