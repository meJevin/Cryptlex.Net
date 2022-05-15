﻿using Cryptlex.Net.Core.Services.Base;
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
        IListable<TrialActivation, GetAllTrialActivationsData>,
        ICreatable<TrialActivation, CreateTrialActivationData>,
        IRetrievable<TrialActivation>,
        IDeletable<TrialActivation>
    {
        Task<Stream> ExportAll(ExportTrialActivationsData data);
        Task<TrialActivation> Extend(string id, ExtendTrialActivationData data);
        Task<OfflineActivateResponse> OfflineActivate(OfflineActivateData data);
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
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<TrialActivation> CreateAsync(CreateTrialActivationData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }

        public async Task<TrialActivation> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<IEnumerable<TrialActivation>> ListAsync(GetAllTrialActivationsData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async Task<Stream> ExportAll(ExportTrialActivationsData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var result = await RequestAsync(uri, HttpMethod.Get, data);

            result.ThrowIfFailed("Could not export all trial activations.");

            var stream = await result.ResponseMessage.Content.ReadAsStreamAsync();

            return stream;
        }

        public async Task<TrialActivation> Extend(string id, ExtendTrialActivationData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Could not extend trial activations with id {id}.");

            var resultData = await result.ContentToAsync<TrialActivation>();

            return resultData;
        }

        public async Task<OfflineActivateResponse> OfflineActivate(OfflineActivateData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Could not create an offline trial activation for product with id {data.productId}");

            var resultData = await result.ContentToAsync<OfflineActivateResponse>();

            return resultData;
        }
    }
}