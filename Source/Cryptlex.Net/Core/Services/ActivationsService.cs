using Cryptlex.Net.Activations;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Responses;
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
    public interface IActivationsService
    {
        Task<IEnumerable<Activation>> GetAllAsync(GetAllActivationsData data);
        Task<Activation> CreateAsync(CreateActivationData data);
        Task<Activation> GetAsync(string id);
        Task<Activation> UpdateAsync(string id, UpdateActivationData data);
        Task DeleteAsync(string id);
        Task<OfflineActivationResponse> OfflineActivate(OfflineActivateData data);
        Task OfflineDeactivate(OfflineDeactivateData data);
        Task<IncrementActivationUsageResponse> IncrementUsage(string id, IncrementActivationUsageData data);
    }

    public class ActivationsService : BaseService<Activation>, IActivationsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Activations);

        public static class Actions
        {
            public static string OfflineActivate = "offline-activate";
            public static string OfflineDeactivate = "offline-deactivate";
            public static string MeterAttributes = "meter-attributes";
        }

        public ActivationsService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<Activation>> GetAllAsync(GetAllActivationsData data)
        {
            return await base.GenericGetAllAsync(data);
        }

        public async Task<Activation> CreateAsync(CreateActivationData data)
        {
            return await base.GenericCreateAsync(data);
        }

        public async Task<Activation> GetAsync(string id)
        {
            return await base.GenericGetAsync(id);
        }

        public async Task<Activation> UpdateAsync(string id, UpdateActivationData data)
        {
            return await base.GenericUpdateAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.GenericDeleteAsync(id);
        }

        public async Task<OfflineActivationResponse> OfflineActivate(OfflineActivateData data)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.OfflineActivate);

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
            
            var uri = Utils.CombinePaths(BasePath, Actions.OfflineDeactivate);

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not delete an activation offline in cryptlex. Error message: {error.message}", error);
            }
        }

        public async Task<IncrementActivationUsageResponse> IncrementUsage(string id, IncrementActivationUsageData data)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.MeterAttributes, id);

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not increment meter attribute for activation with id {id} in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<IncrementActivationUsageResponse>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }
    }
}
