using Cryptlex.Net.Licenses;
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
using Cryptlex.Net.Core.Services.Base;

namespace Cryptlex.Net.Core.Services
{
    public interface ILicensesService :
        IListable<License, ListLicensesData>,
        ICreatable<License, CreateLicenseData>,
        IRetrievable<License>,
        IUpdatable<License, UpdateLicenseData>,
        IDeletable<License>
    {
        Task<Stream> ExportAllAsync(ExportAllLicensesData data, RequestOptions? requestOptions = null);
        Task<License> RenewAsync(string id, RequestOptions? requestOptions = null);
        Task<License> ExtendAsync(string id, TimeSpan extendFor, RequestOptions? requestOptions = null);
        Task<License> ResetMeterAttribute(string id, RequestOptions? requestOptions = null);
        Task DeleteMeterAttribute(string id, RequestOptions? requestOptions = null);
        Task DeleteMetadataField(string id, RequestOptions? requestOptions = null);
    }

    public class LicensesService : BaseService<License>, ILicensesService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Licenses);

        public static class Actions
        {
            public static string Export = "export";
            public static string Renew = "renew";
            public static string Extend = "extend";
            public static string MeterAttributes = "meter-attributes";
            public static string Reset = "reset";
            public static string Metadata = "metadata";
        }

        public LicensesService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory tokenFactory) 
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<IEnumerable<License>> ListAsync(ListLicensesData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<License> CreateAsync(CreateLicenseData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<License> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<License> UpdateAsync(string id, UpdateLicenseData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }

        public async Task<Stream> ExportAllAsync(ExportAllLicensesData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var result = await RequestAsync(uri, HttpMethod.Get, data, requestOptions);

            result.ThrowIfFailed($"Could not export all licenses.");

            return await result.ResponseMessage.Content.ReadAsStreamAsync();
        }

        public async Task<License> RenewAsync(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Renew);

            var result = await RequestAsync(uri, HttpMethod.Post, requestOptions: requestOptions);

            result.ThrowIfFailed($"Could not renew license with id {id}.");

            var resultData = await result.ExtractDataAsync<License>();

            return resultData;
        }

        public async Task<License> ExtendAsync(string id, TimeSpan extendFor, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Extend);

            var result = await RequestAsync(uri, HttpMethod.Post, new ExtendLicenseData((int)extendFor.TotalSeconds), requestOptions);

            result.ThrowIfFailed($"Could not extend license with id {id}.");

            var resultData = await result.ExtractDataAsync<License>();

            return resultData;
        }

        public async Task<License> ResetMeterAttribute(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.MeterAttributes, id, Actions.Reset);

            var result = await RequestAsync(uri, HttpMethod.Post, requestOptions: requestOptions);

            result.ThrowIfFailed($"Could not reset meter attribute for license with id {id}.");

            var resultData = await result.ExtractDataAsync<License>();

            return resultData;
        }

        public async Task DeleteMeterAttribute(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.MeterAttributes, id);

            var result = await RequestAsync(uri, HttpMethod.Delete, requestOptions: requestOptions);

            result.ThrowIfFailed($"Could not delete meter attribute for license with id {id}.");
        }

        public async Task DeleteMetadataField(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Metadata, id);

            var result = await RequestAsync(uri, HttpMethod.Delete, requestOptions: requestOptions);

            result.ThrowIfFailed($"Could not delete metadata for license with id {id}.");
        }
    }
}
