﻿using Cryptlex.Net.Activations;
using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
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
    public interface IActivationsService :
        IListable<Activation, ListActivationsData>,
        ICreatable<Activation, CreateActivationData>,
        IRetrievable<Activation>,
        IUpdatable<UpdateActivationResponse, UpdateActivationData>,
        IDeletable<Activation>
    {
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

        public async Task<IEnumerable<Activation>> ListAsync(ListActivationsData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<Activation> ListAutoPagingAsync(ListActivationsData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<Activation> CreateAsync(CreateActivationData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<Activation> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<UpdateActivationResponse> UpdateAsync(string id, UpdateActivationData data)
        {
            return await base.UpdateEntityAsync<UpdateActivationResponse>(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }

        public async Task<OfflineActivationResponse> OfflineActivate(OfflineActivateData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.OfflineActivate);

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Could not perform offline activation for {data.LicenseId}.");

            var resultData = await result.ExtractDataAsync<OfflineActivationResponse>();

            return resultData;
        }

        public async Task OfflineDeactivate(OfflineDeactivateData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.OfflineDeactivate);

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Could not perform offline deactivation for {data.LicenseId}.");
        }

        public async Task<IncrementActivationUsageResponse> IncrementUsage(string id, IncrementActivationUsageData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.MeterAttributes, id);

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Could not increment usage for {id}.");

            var resultData = await result.ExtractDataAsync<IncrementActivationUsageResponse>();

            return resultData;
        }
    }
}
