using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Users;
using Cryptlex.Net.Users.Current;
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
        Task<IEnumerable<License>> ListLicensesAsync(ListCurrentUserLicensesData data);
        Task<Activation> GetActivationAsync(string id);
        Task<IEnumerable<Activation>> ListActivateionsAsync(ListCurrentUserActivationsData data);
        Task<IEnumerable<Release>> ListReleasesAsync(ListCurrentUserReleasesData data);
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
            return await GetFromSelfAsync<User>(BasePath);
        }

        public async Task<User> UpdateAsync(UpdateCurrentUserData data)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Patch, data);

            result.ThrowIfFailed($"Could not update current user.");

            var resultData = await result.ContentToAsync<User>();

            return resultData;
        }
        
        public async Task<License> GetLicenseAsync(string id)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.License, id);

            return await GetFromSelfAsync<License>(uri);
        }

        public async Task<IEnumerable<License>> ListLicensesAsync(ListCurrentUserLicensesData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Licenses);

            return await GetFromSelfAsync<IEnumerable<License>>(uri, data);
        }

        public async Task<Activation> GetActivationAsync(string id)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Activation, id);

            return await GetFromSelfAsync<Activation>(uri);
        }

        public async Task<IEnumerable<Activation>> ListActivateionsAsync(ListCurrentUserActivationsData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Activations);

            return await GetFromSelfAsync<IEnumerable<Activation>>(uri, data);
        }

        public async Task<IEnumerable<Release>> ListReleasesAsync(ListCurrentUserReleasesData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Releases);

            return await GetFromSelfAsync<IEnumerable<Release>>(uri, data);
        }

        protected virtual async Task<T> GetFromSelfAsync<T>(string uri, object? data = null) where T : class
        {
            var result = await RequestAsync(uri, HttpMethod.Get, data);

            result.ThrowIfFailed($"Get from self for {uri} failed.");

            var resultData = await result.ContentToAsync<T>();

            return resultData;
        }
    }
}
