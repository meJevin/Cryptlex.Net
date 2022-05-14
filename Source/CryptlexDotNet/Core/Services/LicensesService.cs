﻿using CryptlexDotNet.Licenses;
using CryptlexDotNet.Entities;
using CryptlexDotNet.Exceptions;
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
    public interface ILicensesService
    {
        Task<IEnumerable<License>> GetAllAsync(GetAllLicensesData data);
        Task<License> CreateAsync(CreateLicenseData data);
        Task<License> GetAsync(string id);
        Task<License> UpdateAsync(string id, UpdateLicenseData data);
        Task DeleteAsync(string id);
        Task ExportAllAsync(ExportAllLicensesData data);
        Task<License> RenewAsync(string id);
        Task<License> ExtendAsync(string id, TimeSpan extendFor);
        Task<License> ResetMeterAttribute(string id);
        Task DeleteMeterAttribute(string id);
        Task DeleteMetadataField(string id);
    }

    public class LicensesService : BaseService, ILicensesService
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

        public async Task<IEnumerable<License>> GetAllAsync(GetAllLicensesData data)
        {
            using var client = GetCryptlexClient();

            var uri = BasePath;
            var queryStr = data.ToQueryString();

            var res = await client.GetAsync(uri.AppendQueryString(queryStr));

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not get licenses from cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<IEnumerable<License>>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<License> CreateAsync(CreateLicenseData data)
        {
            using var client = GetCryptlexClient();

            var uri = BasePath;

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not create license in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<License>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<License> GetAsync(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id);
            var res = await client.GetAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not get license with id {id} from cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<License>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<License> UpdateAsync(string id, UpdateLicenseData data)
        {
            using var client = GetCryptlexClient();

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var uri = Utils.CombinePaths(BasePath, id);
            var res = await client.PatchAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not update license with id {id} in cryptlex. Error message: {error.message}");
            }

            var resObject = JsonSerializer.Deserialize<License>(await res.Content.ReadAsStringAsync())!;

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
                throw new CryptlexException($"Could not delete license with id {id} in cryptlex. Error message: {error.message}");
            }
        }

        public async Task ExportAllAsync(ExportAllLicensesData data)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.Export);
            var queryStr = data.ToQueryString();

            var res = await client.GetAsync(uri.AppendQueryString(queryStr));

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not export licenses from cryptlex. Error message: {error.message}", error);
            }
        }

        public async Task<License> RenewAsync(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id, Actions.Renew);

            var res = await client.PostAsync(uri, null);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not renew license with id {id} in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<License>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<License> ExtendAsync(string id, TimeSpan extendFor)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id, Actions.Extend);

            var jsonToSend = JsonSerializer.Serialize(new ExtendLicenseData((int)extendFor.TotalSeconds));
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);
            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not extend license with id {id} in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<License>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<License> ResetMeterAttribute(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.MeterAttributes, id, Actions.Reset);

            var res = await client.PostAsync(uri, null);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not reset meter attribute for license with id {id} in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<License>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task DeleteMeterAttribute(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.MeterAttributes, id);

            var res = await client.DeleteAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not delete meter attribute for license with id {id} in cryptlex. Error message: {error.message}", error);
            }
        }

        public async Task DeleteMetadataField(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.Metadata, id);

            var res = await client.DeleteAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not delete metadata field for license with id {id} in cryptlex. Error message: {error.message}", error);
            }
        }
    }
}
