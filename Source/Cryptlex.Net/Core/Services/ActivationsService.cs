using Cryptlex.Net.Activations;
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
        Task<OfflineActivationResponse> OfflineActivate(OfflineActivateData data, RequestOptions? requestOptions = null);
        Task OfflineDeactivate(OfflineDeactivateData data, RequestOptions? requestOptions = null);
        Task<IncrementActivationUsageResponse> IncrementUsage(string id, IncrementActivationUsageData data, RequestOptions? requestOptions = null);
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
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<IEnumerable<Activation>> ListAsync(ListActivationsData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<Activation> CreateAsync(CreateActivationData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<Activation> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<UpdateActivationResponse> UpdateAsync(string id, UpdateActivationData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync<UpdateActivationResponse>(id, data);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }

        public async Task<OfflineActivationResponse> OfflineActivate(OfflineActivateData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.OfflineActivate);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not perform offline activation for {data.licenseId}.");

            var resultData = await result.ExtractDataAsync<OfflineActivationResponse>();

            return resultData;
        }

        public async Task OfflineDeactivate(OfflineDeactivateData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.OfflineDeactivate);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not perform offline deactivation for {data.licenseId}.");
        }

        public async Task<IncrementActivationUsageResponse> IncrementUsage(string id, IncrementActivationUsageData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.MeterAttributes, id);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not increment usage for {id}.");

            var resultData = await result.ExtractDataAsync<IncrementActivationUsageResponse>();

            return resultData;
        }
    }
}
