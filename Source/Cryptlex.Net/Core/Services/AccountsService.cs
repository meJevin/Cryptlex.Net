using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Accounts;
using Cryptlex.Net.Util;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using Cryptlex.Net.Exceptions;

namespace Cryptlex.Net.Core.Services
{
    public interface IAccountsService :
        ICreatable<Account, CreateAccountData>,
        IRetrievable<Account>,
        IUpdatable<Account, UpdateAccountData>
    {
        Task<AccountLoginResponse> Login(AccountLoginData data);
        Task<AccountLoginGoogleResponse> LoginGoogle(AccountLoginGoogleData data);
        Task ResetPassowrd(AccountResetPasswordData data);
        Task<Account> UpdateStatus(string id, UpdateAccountStatusData data);
        Task<Account> UpdatePlan(string id, UpdateAccountPlanData data);
    }

    public class AccountsService : BaseService<Account>, IAccountsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Accounts);

        public static class Actions
        {
            public static string Login = "login";
            public static string LoginGoogle = "login-google";
            public static string ResetPasswordRequest = "reset-password-request";
            public static string Status = "status";
            public static string Plan = "plan";
        }

        public AccountsService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {

        }

        public async Task<Account> CreateAsync(CreateAccountData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<Account> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<Account> UpdateAsync(string id, UpdateAccountData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task<AccountLoginResponse> Login(AccountLoginData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Login);

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Could not login into account with email {data.email}.");

            var resultData = await result.ExtractDataAsync<AccountLoginResponse>();

            return resultData;
        }

        public async Task<AccountLoginGoogleResponse> LoginGoogle(AccountLoginGoogleData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.LoginGoogle);

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Could not login into account with email {data.email}.");

            var resultData = await result.ExtractDataAsync<AccountLoginGoogleResponse>();

            return resultData;
        }

        public async Task ResetPassowrd(AccountResetPasswordData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.ResetPasswordRequest);

            var result = await RequestAsync(uri, HttpMethod.Post, data);

            result.ThrowIfFailed($"Could not reset password for account with email {data.email}.");
        }

        public async Task<Account> UpdateStatus(string id, UpdateAccountStatusData data)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Status);

            var result = await RequestAsync(uri, HttpMethod.Put, data);

            result.ThrowIfFailed($"Could not update status for acount with id {id}");

            var resultData = await result.ExtractDataAsync<Account>();

            return resultData;
        }

        public async Task<Account> UpdatePlan(string id, UpdateAccountPlanData data)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.Plan);

            var result = await RequestAsync(uri, HttpMethod.Put, data);

            result.ThrowIfFailed($"Could not update plan for acount with id {id}");

            var resultData = await result.ExtractDataAsync<Account>();

            return resultData;
        }
    }
}
