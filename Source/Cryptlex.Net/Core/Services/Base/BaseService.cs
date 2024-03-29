﻿using Cryptlex.Net.Core;
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
        private async Task<RequestResult> QueryStringRequest(string uri, object? data = null!)
        {
            using var client = await GetCryptlexClient();

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
            using var client = await GetCryptlexClient();

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

        public virtual async Task<RequestResult> RequestAsync(string uri, HttpMethod method, object? data = null!)
        {
            if (method == HttpMethod.Get)
            {
                return await QueryStringRequest(uri, data);
            }

            return await RequestBodyRequest(uri, method, data);
        }
        #endregion

        #region CRUD

        #region CREATE
        public virtual async Task<TResponse> CreateEntityAsync<TResponse>(object data)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Create for ${uri} failed.");

            var resultData = await result.ExtractDataAsync<TResponse>();

            return resultData;
        }

        public virtual async Task<T> CreateEntityAsync(object data)
        {
            return await CreateEntityAsync<T>(data);
        }
        #endregion

        #region READ
        public virtual async Task<IEnumerable<TResponse>> ListEntitiesAsync<TResponse>(IListRequest? data = null!, string? customUri = null!)
        {
            var uri = customUri ?? BasePath;

            var result = await RequestAsync(uri, HttpMethod.Get, data);

            result.ThrowIfFailed($"List for {uri} failed.");

            var resultData = await result.ExtractDataAsync<IEnumerable<TResponse>>();

            return resultData;
        }

        public virtual async Task<IEnumerable<T>> ListEntitiesAsync(IListRequest? data = null!, string? customUri = null!)
        {
            return await ListEntitiesAsync<T>(data, customUri);
        }

        public virtual async IAsyncEnumerable<TResponse> ListEntitiesAsyncEnumerator<TResponse>(IListRequest? data = null, string? customUri = null!)
        {
            data = data ?? new DefaultListRequest();

            var currentPage = 1;
            IEnumerable<TResponse> items;
            do
            {
                data.Page = currentPage;

                items = await ListEntitiesAsync<TResponse>(data, customUri);

                foreach (var item in items)
                {
                    yield return item;
                }

                currentPage++;
            }
            while (items.Count() is > 0);
        }

        public virtual async IAsyncEnumerable<T> ListEntitiesAsyncEnumerator(IListRequest? data = null!, string? customUri = null!)
        {
            await foreach (var item in ListEntitiesAsyncEnumerator<T>(data, customUri))
            {
                yield return item;
            }
        }

        public virtual async Task<T> GetEntityAsync(string id)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Get, null);

            result.ThrowIfFailed($"Get for {uri} failed.");

            var resultData = await result.ExtractDataAsync<T>();

            return resultData;
        }
        #endregion

        #region UPDATE
        public virtual async Task<TResponse> UpdateEntityAsync<TResponse>(string id, object? data = null!)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Patch, data);

            result.ThrowIfFailed($"Update for {uri} failed.");

            var resultData = await result.ExtractDataAsync<TResponse>();

            return resultData;
        }

        public virtual async Task<T> UpdateEntityAsync(string id, object? data = null!)
        {
            return await UpdateEntityAsync<T>(id, data);
        }
        #endregion

        #region DELETE
        public virtual async Task DeleteEntityAsync(string id)
        {
            var uri = Utils.CombinePaths(BasePath, id);

            var result = await RequestAsync(uri, HttpMethod.Delete, null);

            result.ThrowIfFailed($"Delete for {uri} failed.");
        }
        #endregion
        #endregion

        public virtual async Task<HttpClient> GetCryptlexClient()
        {
            var client = _httpClientFactory.CreateClient();
            var token = await _tokenFactory.GetAccessTokenAsync();

            client.BaseAddress = new Uri(API.Address);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                API.AuthenticationScheme, token);

            return client;
        }
    }
}
