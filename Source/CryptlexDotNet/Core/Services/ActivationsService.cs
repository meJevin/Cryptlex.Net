using CryptlexDotNet.Activations;
using CryptlexDotNet.Entities;
using CryptlexDotNet.Exceptions;
using CryptlexDotNet.Responses;
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
    public interface IActivationsService
    {
        Task<IEnumerable<Activation>> GetAllAsync(GetAllActivationsData data);
        Task<Activation> CreateAsync(CreateActivationData data);
        Task<Activation> GetAsync(string id);
        Task<Activation> UpdateAsync(string id, UpdateActivationData data);
        Task DeleteAsync(string id);
        Task<OfflineActivationResponse> OfflineActivate(OfflineActivateData data);
        Task OfflineDeactivate(OfflineDeactivateData data);
        Task<IncrementActivationMeterAttributeResponse> IncrementMeterAttribute(
            string id, IncrementActivationMeterAttributeData data);
    }

    public class ActivationsService : BaseService, IActivationsService
    {
        protected override string Path => UriHelper.CombinePaths(API.Version, API.Paths.Activations);

        public ActivationsService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<Activation>> GetAllAsync(GetAllActivationsData data)
        {
            using var client = GetCryptlexClient();

            var uri = Path;
            var queryStr = data.ToQueryString();

            var res = await client.GetAsync(uri.AddQueryString(queryStr));

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not get activations from cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<IEnumerable<Activation>>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<Activation> CreateAsync(CreateActivationData data)
        {
            using var client = GetCryptlexClient();

            var uri = Path;

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not create activation in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<Activation>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<Activation> GetAsync(string id)
        {
            using var client = GetCryptlexClient();

            var uri = UriHelper.CombinePaths(Path, id);
            var res = await client.GetAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not get license with id {id} from cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<Activation>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<Activation> UpdateAsync(string id, UpdateActivationData data)
        {
            using var client = GetCryptlexClient();

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var uri = UriHelper.CombinePaths(Path, id);
            var res = await client.PatchAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not update activation with id {id} in cryptlex. Error message: {error.message}");
            }

            var resObject = JsonSerializer.Deserialize<Activation>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task DeleteAsync(string id)
        {
            using var client = GetCryptlexClient();

            var uri = UriHelper.CombinePaths(Path, id);
            var res = await client.DeleteAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not delete activation with id {id} in cryptlex. Error message: {error.message}");
            }
        }

        public async Task<OfflineActivationResponse> OfflineActivate(OfflineActivateData data)
        {
            using var client = GetCryptlexClient();

            var uri = UriHelper.CombinePaths(Path, "offline-activate");

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not create offline activation in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<OfflineActivationResponse>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task OfflineDeactivate(OfflineDeactivateData data)
        {
            using var client = GetCryptlexClient();

            var uri = UriHelper.CombinePaths(Path, "offline-deactivate");

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not delete an activation offline in cryptlex. Error message: {error.message}", error);
            }
        }

        public async Task<IncrementActivationMeterAttributeResponse> IncrementMeterAttribute(
            string id, IncrementActivationMeterAttributeData data)
        {
            using var client = GetCryptlexClient();

            var uri = Path;

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not increment meter attribute for activation with id {id} in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<IncrementActivationMeterAttributeResponse>(
                await res.Content.ReadAsStringAsync())!;

            return resObject;
        }
    }
}
