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
        Task ExportAllAsync(ExportAllLicensesData data);
        Task<License> RenewAsync(string id);
        Task<License> ExtendAsync(string id, TimeSpan extendFor);
        Task<License> ResetMeterAttribute(string id);
        Task DeleteMeterAttribute(string id);
        Task DeleteMetadataField(string id);
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
            IOptions<CryptlexClientSettings> cryptlexSettings) 
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<License>> ListAsync(ListLicensesData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async Task<License> CreateAsync(CreateLicenseData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<License> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<License> UpdateAsync(string id, UpdateLicenseData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }

        public async Task ExportAllAsync(ExportAllLicensesData data)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var result = await RequestAsync(uri, HttpMethod.Get, data);

            result.ThrowIfFailed($"Could not export all licenses.");
        }

        public async Task<License> RenewAsync(string id)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Renew);

            var result = await RequestAsync(uri, HttpMethod.Post, null);

            result.ThrowIfFailed($"Could not renew license with id {id}.");

            var resultData = await result.ContentToAsync<License>();

            return resultData;
        }

        public async Task<License> ExtendAsync(string id, TimeSpan extendFor)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Extend);

            var result = await RequestAsync(uri, HttpMethod.Post, null);

            result.ThrowIfFailed($"Could not extend license with id {id}.");

            var resultData = await result.ContentToAsync<License>();

            return resultData;
        }

        public async Task<License> ResetMeterAttribute(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.MeterAttributes, id, Actions.Reset);

            var result = await RequestAsync(uri, HttpMethod.Post, null);

            result.ThrowIfFailed($"Could not reset meter attribute for license with id {id}.");

            var resultData = await result.ContentToAsync<License>();

            return resultData;
        }

        public async Task DeleteMeterAttribute(string id)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.MeterAttributes, id);

            var result = await RequestAsync(uri, HttpMethod.Delete, null);

            result.ThrowIfFailed($"Could not delete meter attribute for license with id {id}.");
        }

        public async Task DeleteMetadataField(string id)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Metadata, id);

            var result = await RequestAsync(uri, HttpMethod.Delete, null);

            result.ThrowIfFailed($"Could not delete metadata for license with id {id}.");
        }
    }
}
