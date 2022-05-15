using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Util;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Cryptlex.Net.Core.Services
{
    public class RequestResult
    {
        public HttpResponseMessage ResponseMessage { get; private set; }
        public Error? CryptlexError { get; private set; }
        public string? ReasonPhrase { get; private set; }

        public bool IsSuccessStatusCode => ResponseMessage is not null && ResponseMessage.IsSuccessStatusCode;

        private RequestResult(HttpResponseMessage responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public async Task<T> ContentToAsync<T>() where T : class?
        {
            var stringContent = await ResponseMessage.Content.ReadAsStringAsync();

            if (stringContent is null) return null;

            return JsonSerializer.Deserialize<T>(stringContent)!;
        }

        public override string ToString()
        {
            if (IsSuccessStatusCode) return String.Empty;

            var errors = new List<string>();

            errors.Add($"Failed with code {ResponseMessage.StatusCode}");

            if (CryptlexError is not null)
            {
                errors.Add($"Cryptlex error: {CryptlexError.message}");
            }

            if (ReasonPhrase is not null)
            {
                errors.Add($"Reason phrase: {ReasonPhrase}");
            }

            return String.Join(". ", errors);
        }

        public void ThrowIfFailed(string? errorStartMsg)
        {
            if (IsSuccessStatusCode) return;

            if (CryptlexError is not null)
            {
                throw new CryptlexException(errorStartMsg + " " + ToString());
            }

            if (ReasonPhrase is not null)
            {
                throw new HttpRequestException(errorStartMsg + " " + ToString());
            }
        }

        public static async Task<RequestResult> FromHttpResponseAsync(HttpResponseMessage message)
        {
            var result = new RequestResult(message);

            if (!message.IsSuccessStatusCode)
            {
                result.CryptlexError = await message.Content.ReadCryptlexErrorAsync();
                result.ReasonPhrase = message.ReasonPhrase;
            }

            return result;
        }
    }

    public class EntityUpdatePutOptions
    {
        public string PutUri { get; set; }

        public EntityUpdatePutOptions(string customUri)
        {
            PutUri = customUri;
        }
    }

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

        #region HTTP REQUESTS
        private async Task<RequestResult> QueryStringRequest(string uri, object? data = null!)
        {
            using var client = GetCryptlexClient();

            if (data is not null)
            {
                Utils.AppendQueryString(uri, data.ToQueryString());
            }

            var httpRes = await client.GetAsync(uri);

            var requestRes = await RequestResult.FromHttpResponseAsync(httpRes);

            return requestRes;
        }
        private async Task<RequestResult> RequestBodyRequest(string uri, HttpMethod method, object? data = null!)
        {
            using var client = GetCryptlexClient();

            StringContent? content = null!;

            if (data is not null)
            {
                var jsonToSend = JsonSerializer.Serialize(data);
                content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);
            }

            HttpResponseMessage? httpRes = null!;

            if (method == HttpMethod.Post)
            {
                httpRes = await client.PostAsync(uri, content);
            }
            else if (method == HttpMethod.Put)
            {
                httpRes = await client.PutAsync(uri, content);
            }
            else if (method == HttpMethod.Patch)
            {
                httpRes = await client.PatchAsync(uri, content);
            }
            else if (method == HttpMethod.Delete)
            {
                httpRes = await client.DeleteAsync(uri);
            }
            else
            {
                throw new ArgumentException($"Method {method} not supported!");
            }

            var requestRes = await RequestResult.FromHttpResponseAsync(httpRes);

            return requestRes;
        }

        protected virtual async Task<RequestResult> RequestAsync(string uri, HttpMethod method, object? data = null!)
        {
            if (method == HttpMethod.Get)
            {
                return await QueryStringRequest(uri, data);
            }

            return await RequestBodyRequest(uri, method, data);
        }
        #endregion

        #region CRUD
        protected virtual async Task<IEnumerable<T>> ListEntitiesAsync(object? data = null!)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Get, data);

            result.ThrowIfFailed($"List for {uri} failed.");

            var resultData = await result.ContentToAsync<IEnumerable<T>>();

            return resultData;
        }

        protected virtual async Task<T> CreateEntityAsync(object data)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Create for ${uri} failed.");

            var resultData = await result.ContentToAsync<T>();

            return resultData;
        }

        protected virtual async Task<T> GetEntityAsync(string id)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Get, null);

            result.ThrowIfFailed($"Get for {uri} failed.");

            var resultData = await result.ContentToAsync<T>();

            return resultData;
        }

        protected virtual async Task<T> UpdateEntityAsync(string id, object? data = null!, 
            EntityUpdatePutOptions? putOptions = null!)
        {
            var usePut = putOptions is not null;

            var uri = usePut ? putOptions!.PutUri : Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, usePut ? HttpMethod.Put : HttpMethod.Patch, data);

            result.ThrowIfFailed($"Update for {uri} failed.");

            var resultData = await result.ContentToAsync<T>();

            return resultData;
        }

        protected virtual async Task DeleteEntityAsync(string id)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Delete, null);

            result.ThrowIfFailed($"Delete for {uri} failed.");
        }
        #endregion

        protected virtual HttpClient GetCryptlexClient()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(API.Address);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                API.AuthenticationScheme, _cryptlexSettings.AccessToken);

            return client;
        }
    }
}
