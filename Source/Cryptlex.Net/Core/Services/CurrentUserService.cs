using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Requests.Users.Current;
using Cryptlex.Net.Users;
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
    public interface ICurrentUserService
    {
        Task<User> GetAsync();
        Task<User> UpdateAsync(UpdateCurrentUserData data);
        Task<License> GetLicenseAsync(string id);
        Task<IEnumerable<License>> GetAllLicensesAsync(GetAllCurrentUserLicensesData data);
        Task<Activation> GetActivationAsync(string id);
        Task<IEnumerable<Activation>> GetAllActivateionsAsync(GetAllCurrentUserActivationsData data);
        Task<IEnumerable<Release>> GetAllReleasesAsync(GetAllCurrentUserReleasesData data);
    }


    public class CurrentUserService : BaseService<User>, ICurrentUserService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Me);

        public static class Actions
        {
            public static string License = "license";
            public static string Licenses = "licenses";
            public static string Activation = "activation";
            public static string Activations = "activations";
            public static string Releases = "releases";
        }

        public CurrentUserService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<User> GetAsync()
        {
            return await GetAsync<User>(BasePath);
        }

        public async Task<User> UpdateAsync(UpdateCurrentUserData data)
        {
            using var client = GetCryptlexClient();

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);

            var uri = BasePath;

            var res = await client.PatchAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not update current user in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<User>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }
        
        public async Task<License> GetLicenseAsync(string id)
        {
            return await GetAsync<License>(Utils.CombinePaths(BasePath, Actions.License, id));
        }

        public async Task<IEnumerable<License>> GetAllLicensesAsync(GetAllCurrentUserLicensesData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Licenses);
            uri.AppendQueryString(data.ToQueryString());

            return await GetAsync<IEnumerable<License>>(uri);
        }

        public async Task<Activation> GetActivationAsync(string id)
        {
            return await GetAsync<Activation>(Utils.CombinePaths(BasePath, Actions.Activation, id));
        }

        public async Task<IEnumerable<Activation>> GetAllActivateionsAsync(GetAllCurrentUserActivationsData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Activations);
            uri.AppendQueryString(data.ToQueryString());

            return await GetAsync<IEnumerable<Activation>>(uri);
        }

        public async Task<IEnumerable<Release>> GetAllReleasesAsync(GetAllCurrentUserReleasesData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Releases);
            uri.AppendQueryString(data.ToQueryString());

            return await GetAsync<IEnumerable<Release>>(uri);
        }

        protected virtual async Task<T> GetAsync<T>(string uri)
        {
            using var client = GetCryptlexClient();

            var res = await client.GetAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Get failed for path {uri}. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<T>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }
    }
}
