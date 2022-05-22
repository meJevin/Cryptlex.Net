using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.TrialActivations;
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
    public interface ITrialActivationsService :
        IListable<TrialActivation, ListTrialActivationsData>,
        ICreatable<TrialActivation, CreateTrialActivationData>,
        IRetrievable<TrialActivation>,
        IDeletable<TrialActivation>
    {
        Task<Stream> ExportAll(ExportTrialActivationsData data, RequestOptions? requestOptions = null);
        Task<TrialActivation> Extend(string id, ExtendTrialActivationData data, RequestOptions? requestOptions = null);
        Task<OfflineActivateResponse> OfflineActivate(OfflineActivateData data, RequestOptions? requestOptions = null);
    }

    public class TrialActivationsService : BaseService<TrialActivation>, ITrialActivationsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.TrialActivations);

        public static class Actions
        {
            public static string Export = "export";
            public static string Extend = "extend";
            public static string OfflineActivate = "offline-activate";
        }

        public TrialActivationsService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<TrialActivation> CreateAsync(CreateTrialActivationData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }

        public async Task<TrialActivation> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<IEnumerable<TrialActivation>> ListAsync(ListTrialActivationsData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<Stream> ExportAll(ExportTrialActivationsData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var result = await RequestAsync(uri, HttpMethod.Get, data, requestOptions);

            result.ThrowIfFailed("Could not export all trial activations.");

            var stream = await result.ResponseMessage.Content.ReadAsStreamAsync();

            return stream;
        }

        public async Task<TrialActivation> Extend(string id, ExtendTrialActivationData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not extend trial activations with id {id}.");

            var resultData = await result.ExtractDataAsync<TrialActivation>();

            return resultData;
        }

        public async Task<OfflineActivateResponse> OfflineActivate(OfflineActivateData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not create an offline trial activation for product with id {data.productId}");

            var resultData = await result.ExtractDataAsync<OfflineActivateResponse>();

            return resultData;
        }
    }
}
