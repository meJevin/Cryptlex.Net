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
        private readonly ICryptlexAccessTokenFactory _tokenFactory;

        protected abstract string BasePath { get; }

        public BaseService(
            IHttpClientFactory httpClientFactory, 
            ICryptlexAccessTokenFactory tokenFactory)
        {
            _httpClientFactory = httpClientFactory;
            _tokenFactory = tokenFactory;
        }

        #region HTTP REQUESTS
        private async Task<RequestResult> QueryStringRequest(string uri, object? data = null, RequestOptions? requestOptions = null)
        {
            using var client = await GetCryptlexClientAsync(requestOptions?.AccessToken);

            if (data is not null)
            {
                Utils.AppendQueryString(uri, data.ToQueryString());
            }

            var httpRes = await client.GetAsync(uri);

            var requestRes = await RequestResult.FromHttpResponseAsync(httpRes);

            return requestRes;
        }
        private async Task<RequestResult> RequestBodyRequest(string uri, HttpMethod method, object? data = null, RequestOptions? requestOptions = null)
        {
            using var client = await GetCryptlexClientAsync(requestOptions?.AccessToken);

            StringContent? content = null;

            if (data is not null)
            {
                var jsonToSend = JsonSerializer.Serialize(data);
                content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);
            }

            HttpResponseMessage? httpRes = null;

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

        protected virtual async Task<RequestResult> RequestAsync(string uri, HttpMethod method, object? data = null, RequestOptions? requestOptions = null)
        {
            if (method == HttpMethod.Get)
            {
                return await QueryStringRequest(uri, data, requestOptions);
            }

            return await RequestBodyRequest(uri, method, data, requestOptions);
        }
        #endregion

        #region CRUD
        protected virtual async Task<IEnumerable<T>> ListEntitiesAsync(object? data = null, RequestOptions? requestOptions = null)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Get, data, requestOptions);

            result.ThrowIfFailed($"List for {uri} failed.");

            var resultData = await result.ExtractDataAsync<IEnumerable<T>>();

            return resultData;
        }

        protected virtual async Task<T> CreateEntityAsync(object data, RequestOptions? requestOptions = null)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Create for ${uri} failed.");

            var resultData = await result.ExtractDataAsync<T>();

            return resultData;
        }

        protected virtual async Task<T> GetEntityAsync(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Get, requestOptions: requestOptions);

            result.ThrowIfFailed($"Get for {uri} failed.");

            var resultData = await result.ExtractDataAsync<T>();

            return resultData;
        }

        protected virtual async Task<T> UpdateEntityAsync(string id, object? data = null, RequestOptions? requestOptions = null)
        {
            return await UpdateEntityAsync<T>(id, data);
        }

        // Yup, in some cases Cryptlex returns something other than the entity after update ¯\_(ツ)_/¯
        protected virtual async Task<TResponse> UpdateEntityAsync<TResponse>(string id, object? data = null, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Patch, data, requestOptions);

            result.ThrowIfFailed($"Update for {uri} failed.");

            var resultData = await result.ExtractDataAsync<TResponse>();

            return resultData;
        }

        protected virtual async Task DeleteEntityAsync(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Delete, requestOptions: requestOptions);

            result.ThrowIfFailed($"Delete for {uri} failed.");
        }
        #endregion

        protected virtual async Task<HttpClient> GetCryptlexClientAsync(string? customToken = null)
        {
            var client = _httpClientFactory.CreateClient();

            var token = customToken ?? await _tokenFactory.GetAccessTokenAsync();

            client.BaseAddress = new Uri(API.Address);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                API.AuthenticationScheme, token);

            return client;
        }
    }
}
