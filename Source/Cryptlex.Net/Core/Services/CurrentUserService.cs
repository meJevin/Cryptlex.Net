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
        Task<User> GetAsync(RequestOptions? requestOptions = null);
        Task<User> UpdateAsync(UpdateCurrentUserData data, RequestOptions? requestOptions = null);
        Task<License> GetLicenseAsync(string id, RequestOptions? requestOptions = null);
        Task<IEnumerable<License>> ListLicensesAsync(ListCurrentUserLicensesData data, RequestOptions? requestOptions = null);
        Task<Activation> GetActivationAsync(string id, RequestOptions? requestOptions = null);
        Task<IEnumerable<Activation>> ListActivateionsAsync(ListCurrentUserActivationsData data, RequestOptions? requestOptions = null);
        Task<IEnumerable<Release>> ListReleasesAsync(ListCurrentUserReleasesData data, RequestOptions? requestOptions = null);
        Task<TwoFactorAuthenticationSecretResponse> GetTwoFactorAuthenticationSecretAsync(RequestOptions? requestOptions = null);
        Task<TwoFactorAuthenticationRecoveryCodeResponse> GetTwoFactorAuthenticationRecoveryCodeAsync(RequestOptions? requestOptions = null);
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
            public static string GenerateTwoFactorAuthenticationSecret = "2fa-secret";
            public static string GenerateTwoFactorAuthenticationRecoveryCode = "2fa-recovery-codes";
        }

        public CurrentUserService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<User> GetAsync(RequestOptions? requestOptions = null)
        {
            return await GetFromSelfAsync<User>(BasePath);
        }

        public async Task<User> UpdateAsync(UpdateCurrentUserData data, RequestOptions? requestOptions = null)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Patch, data, requestOptions);

            result.ThrowIfFailed($"Could not update current user.");

            var resultData = await result.ExtractDataAsync<User>();

            return resultData;
        }
        
        public async Task<License> GetLicenseAsync(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.License, id);

            return await GetFromSelfAsync<License>(uri);
        }

        public async Task<IEnumerable<License>> ListLicensesAsync(ListCurrentUserLicensesData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Licenses);

            return await GetFromSelfAsync<IEnumerable<License>>(uri, data);
        }

        public async Task<Activation> GetActivationAsync(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Activation, id);

            return await GetFromSelfAsync<Activation>(uri);
        }

        public async Task<IEnumerable<Activation>> ListActivateionsAsync(ListCurrentUserActivationsData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Activations);

            return await GetFromSelfAsync<IEnumerable<Activation>>(uri, data);
        }

        public async Task<IEnumerable<Release>> ListReleasesAsync(ListCurrentUserReleasesData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Releases);

            return await GetFromSelfAsync<IEnumerable<Release>>(uri, data);
        }

        protected virtual async Task<T> GetFromSelfAsync<T>(string uri, object? data = null, RequestOptions? requestOptions = null) where T : class
        {
            var result = await RequestAsync(uri, HttpMethod.Get, data, requestOptions);

            result.ThrowIfFailed($"Get from self for {uri} failed.");

            var resultData = await result.ExtractDataAsync<T>();

            return resultData;
        }

        public async Task<TwoFactorAuthenticationSecretResponse> GetTwoFactorAuthenticationSecretAsync(RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.GenerateTwoFactorAuthenticationSecret);

            var result = await RequestAsync(uri, HttpMethod.Post, requestOptions: requestOptions);

            result.ThrowIfFailed("Could not generate 2FA secret.");

            var resultData = await result.ExtractDataAsync<TwoFactorAuthenticationSecretResponse>();

            return resultData;
        }

        public async Task<TwoFactorAuthenticationRecoveryCodeResponse> GetTwoFactorAuthenticationRecoveryCodeAsync(RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.GenerateTwoFactorAuthenticationRecoveryCode);

            var result = await RequestAsync(uri, HttpMethod.Post, requestOptions: requestOptions);

            result.ThrowIfFailed("Could not generate 2FA recovery codes.");

            var resultData = await result.ExtractDataAsync<TwoFactorAuthenticationRecoveryCodeResponse>();

            return resultData;
        }
    }
}
