﻿using Cryptlex.Net.Util;
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

        private async Task<RequestResult> QueryStringRequest(string uri, object? data = null!)
        {
            using var client = GetCryptlexClient();

            if (data is not null)
            {
                uri = Utils.AppendQueryString(uri, data.ToQueryString());
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

        protected virtual async Task<IEnumerable<T>> ListEntitiesAsync(object? data = null!)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Get, data);

            result.ThrowIfFailed($"List for {uri} failed.");

            var resultData = await result.ExtractDataAsync<IEnumerable<T>>();

            return resultData;
        }

        protected virtual async Task<T> CreateEntityAsync(object data)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Create for ${uri} failed.");

            var resultData = await result.ExtractDataAsync<T>();

            return resultData;
        }

        protected virtual async Task<T> GetEntityAsync(string id)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Get, null);

            result.ThrowIfFailed($"Get for {uri} failed.");

            var resultData = await result.ExtractDataAsync<T>();

            return resultData;
        }

        protected virtual async Task<T> UpdateEntityAsync(string id, object? data = null!)
        {
            return await UpdateEntityAsync<T>(id, data);
        }

        // Yup, in some cases Cryptlex returns something other than the entity after update ¯\_(ツ)_/¯
        protected virtual async Task<TResponse> UpdateEntityAsync<TResponse>(string id, object? data = null!)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Patch, data);

            result.ThrowIfFailed($"Update for {uri} failed.");

            var resultData = await result.ExtractDataAsync<TResponse>();

            return resultData;
        }

        protected virtual async Task DeleteEntityAsync(string id)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Delete, null);

            result.ThrowIfFailed($"Delete for {uri} failed.");
        }

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
