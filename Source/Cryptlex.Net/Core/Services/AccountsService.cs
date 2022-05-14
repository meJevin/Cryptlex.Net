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
            return await base.GenericCreateAsync(data);
        }

        public async Task<Account> GetAsync(string id)
        {
            return await base.GenericGetAsync(id);
        }

        public async Task<Account> UpdateAsync(string id, UpdateAccountData data)
        {
            return await base.GenericGetAsync(id);
        }

        public async Task<AccountLoginResponse> Login(AccountLoginData data)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.Login);

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);
            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not login into account with email {data.email}. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<AccountLoginResponse>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task<AccountLoginGoogleResponse> LoginGoogle(AccountLoginGoogleData data)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.LoginGoogle);

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);
            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not login into account with email {data.email}. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<AccountLoginGoogleResponse>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task ResetPassowrd(AccountResetPasswordData data)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.ResetPasswordRequest);

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);
            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not reset password for account with email {data.email}. Error message: {error.message}", error);
            }
        }

        public async Task<Account> UpdateStatus(string id, UpdateAccountStatusData data)
        {
            return await base.GenericUpdateAsync(id, data, true, Actions.Status);
        }

        public async Task<Account> UpdatePlan(string id, UpdateAccountPlanData data)
        {
            return await base.GenericUpdateAsync(id, data, true, Actions.Plan);
        }
    }
}
