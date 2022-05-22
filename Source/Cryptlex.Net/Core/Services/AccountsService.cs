using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Accounts;
using Cryptlex.Net.Util;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using Cryptlex.Net.Exceptions;
using System.Net;

namespace Cryptlex.Net.Core.Services
{
    public interface IAccountsService :
        ICreatable<Account, CreateAccountData>,
        IRetrievable<Account>,
        IUpdatable<Account, UpdateAccountData>
    {
        Task<AccountLoginResponse> Login(AccountLoginData data, RequestOptions? requestOptions = null);
        Task<AccountLoginGoogleResponse> LoginGoogle(AccountLoginGoogleData data, RequestOptions? requestOptions = null);
        Task<bool> CheckSSOEnabled(string companyId, RequestOptions? requestOptions = null);
        Task<Uri> InitiateSSOLogin(string companyId, string returnUrl, RequestOptions? requestOptions = null);
        Task<Uri> GetSSOReturnUrl(string companyId, RequestOptions? requestOptions = null);
        Task ResetPassowrd(AccountResetPasswordData data, RequestOptions? requestOptions = null);
        Task<Account> UpdateStatus(string id, UpdateAccountStatusData data, RequestOptions? requestOptions = null);
        Task<Account> UpdatePlan(string id, UpdateAccountPlanData data, RequestOptions? requestOptions = null);
    }

    public class AccountsService : BaseService<Account>, IAccountsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Accounts);

        public static class Actions
        {
            public static string Login = "login";
            public static string LoginGoogle = "login-google";
            public static string CheckSSOEnabled = "login/saml/verify";
            public static string InitiateSSOLogin = "login/saml";
            public static string GetSSOReturnUrl = "login/saml/{companyId}/asc";
            public static string ResetPasswordRequest = "reset-password-request";
            public static string Status = "status";
            public static string Plan = "plan";
        }

        public AccountsService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {

        }

        public async Task<Account> CreateAsync(CreateAccountData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<Account> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<Account> UpdateAsync(string id, UpdateAccountData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task<AccountLoginResponse> Login(AccountLoginData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Login);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not login into account with email {data.email}.");

            var resultData = await result.ExtractDataAsync<AccountLoginResponse>();

            return resultData;
        }

        public async Task<AccountLoginGoogleResponse> LoginGoogle(AccountLoginGoogleData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.LoginGoogle);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not login into account with email {data.email}.");

            var resultData = await result.ExtractDataAsync<AccountLoginGoogleResponse>();

            return resultData;
        }

        public async Task<bool> CheckSSOEnabled(string companyId, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.CheckSSOEnabled);

            var result = await RequestAsync(uri, HttpMethod.Post, new AccountCheckSSOEnabledData(companyId), requestOptions);

            result.ThrowIfFailed($"Could not check if SSO is enabled for company id {companyId}.");

            return result.IsSuccessStatusCode;
        }

        public async Task<Uri> InitiateSSOLogin(string companyId, string returnUrl, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.InitiateSSOLogin, companyId);

            var result = await RequestAsync(uri, HttpMethod.Get, new AccountInitiateSSOLoginData(returnUrl), requestOptions);

            result.ThrowIfFailed($"Could not initiate SSO login for company id {companyId} with return URL {returnUrl}.", (code) => code == HttpStatusCode.Redirect);

            var redirectUri = result.ResponseMessage.Headers.Location!;

            return redirectUri;
        }

        public async Task<Uri> GetSSOReturnUrl(string companyId, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.GetSSOReturnUrl).Replace("{companyId}", companyId);

            var result = await RequestAsync(uri, HttpMethod.Get, requestOptions: requestOptions);

            result.ThrowIfFailed($"Could not get SSO return URL for company id {companyId}.", (code) => code == HttpStatusCode.Redirect);

            var redirectUri = result.ResponseMessage.Headers.Location!;

            return redirectUri;
        }

        public async Task ResetPassowrd(AccountResetPasswordData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.ResetPasswordRequest);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not reset password for account with email {data.email}.");
        }

        public async Task<Account> UpdateStatus(string id, UpdateAccountStatusData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Status);

            var result = await RequestAsync(uri, HttpMethod.Put, data, requestOptions);

            result.ThrowIfFailed($"Could not update status for acount with id {id}");

            var resultData = await result.ExtractDataAsync<Account>();

            return resultData;
        }

        public async Task<Account> UpdatePlan(string id, UpdateAccountPlanData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Plan);

            var result = await RequestAsync(uri, HttpMethod.Put, data, requestOptions);

            result.ThrowIfFailed($"Could not update plan for acount with id {id}");

            var resultData = await result.ExtractDataAsync<Account>();

            return resultData;
        }
    }
}
