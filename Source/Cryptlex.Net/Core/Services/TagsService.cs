using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Tags;
using Cryptlex.Net.Util;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cryptlex.Net.Core.Services
{
    public interface ITagsService
    {
        Task<IEnumerable<Tag>> GetAllAsync(GetAllTagsData data);
        Task<Tag> CreateAsync(CreateTagData data);
        Task<Tag> GetAsync(string id);
        Task<Tag> UpdateAsync(string id, UpdateTagData data);
        Task DeleteAsync(string id);
    }

    public class TagsService : BaseService, ITagsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Tags);

        public TagsService(
            IHttpClientFactory httpClientFactory, 
            IOptions<CryptlexClientSettings> cryptlexSettings) 
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<Tag>> GetAllAsync(GetAllTagsData data)
        {
            using var client = GetCryptlexClient();

            var uri = BasePath;
            var queryStr = data.ToQueryString();

            var res = await client.GetAsync(uri.AppendQueryString(queryStr));

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not get tags from cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<IEnumerable<Tag>>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<Tag> CreateAsync(CreateTagData data)
        {
            using var client = GetCryptlexClient();

            var uri = BasePath;

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not create tag in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<Tag>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<Tag> GetAsync(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id);
            var res = await client.GetAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not get tag with id {id} from cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<Tag>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<Tag> UpdateAsync(string id, UpdateTagData data)
        {
            using var client = GetCryptlexClient();

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var uri = Utils.CombinePaths(BasePath, id);
            var res = await client.PatchAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not update tag with id {id} in cryptlex. Error message: {error.message}");
            }

            var resObject = JsonSerializer.Deserialize<Tag>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task DeleteAsync(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id);
            var res = await client.DeleteAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not delete tag with id {id} in cryptlex. Error message: {error.message}");
            }
        }
    }
}
