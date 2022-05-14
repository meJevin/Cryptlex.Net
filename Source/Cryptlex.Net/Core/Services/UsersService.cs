using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
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
    public interface IUsersService :
        IListable<User, GetAllUsersData>,
        ICreatable<User, CreateUserData>,
        IRetrievable<User>,
        IUpdatable<User, UpdateUserData>,
        IDeletable<User>
    {
        Task ExportAllAsync();
        Task UpdatePassword(string id, UpdateUserPasswordData data);
        Task<PasswordResetTokenResponse> GetPasswordResetToken(string id);
        Task ResetPassword(string id, ResetUserPasswordData data);
        ICurrentUserService Current { get; }
    }

    public class UsersService : BaseService<User>, IUsersService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Users);

        public ICurrentUserService Current { get; init; }

        public static class Actions
        {
            public static string Export = "export";
            public static string UpdatePassword = "update-password";
            public static string GetPasswordResetToken = "reset-password-token";
            public static string ResetPassword = "reset-password";
        }

        public UsersService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings,
            ICurrentUserService currentUserService)
            : base(httpClientFactory, cryptlexSettings)
        {
            Current = currentUserService;
        }

        public async Task<IEnumerable<User>> GetAllAsync(GetAllUsersData data)
        {
            return await base.GenericGetAllAsync(data);
        }

        public async Task<User> CreateAsync(CreateUserData data)
        {
            return await base.GenericCreateAsync(data);
        }

        public async Task<User> GetAsync(string id)
        {
            return await base.GenericGetAsync(id);
        }

        public async Task<User> UpdateAsync(string id, UpdateUserData data)
        {
            return await base.GenericUpdateAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.GenericDeleteAsync(id);
        }

        public async Task ExportAllAsync()
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var res = await client.GetAsync(uri);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not export users from cryptlex. Error message: {error.message}", error);
            }
        }

        public async Task UpdatePassword(string id, UpdateUserPasswordData data)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id, Actions.UpdatePassword);

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);
            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not update password for user with id {id} in cryptlex. Error message: {error.message}", error);
            }
        }

        public async Task<PasswordResetTokenResponse> GetPasswordResetToken(string id)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id, Actions.GetPasswordResetToken);

            var res = await client.PostAsync(uri, null);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not get password reset token for user with id {id} in cryptlex. Error message: {error.message}", error);
            }

            var resObject = JsonSerializer.Deserialize<PasswordResetTokenResponse>(await res.Content.ReadAsStringAsync())!;

            return resObject;
        }

        public async Task ResetPassword(string id, ResetUserPasswordData data)
        {
            using var client = GetCryptlexClient();

            var uri = Utils.CombinePaths(BasePath, id, Actions.ResetPassword);

            var jsonToSend = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonToSend, Encoding.UTF8, API.MediaType);
            var res = await client.PostAsync(uri, content);

            if (!res.IsSuccessStatusCode)
            {
                var error = await ReadCryptlexErrorAsync(res.Content);
                throw new CryptlexException($"Could not reset password for user with id {id} in cryptlex. Error message: {error.message}", error);
            }
        }
    }
}
