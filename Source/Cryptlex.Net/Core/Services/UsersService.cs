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
        IListable<User, ListUsersData>,
        ICreatable<User, CreateUserData>,
        IRetrievable<User>,
        IUpdatable<User, UpdateUserData>,
        IDeletable<User>
    {
        Task ExportAllAsync(RequestOptions? requestOptions = null);
        Task UpdatePassword(string id, UpdateUserPasswordData data, RequestOptions? requestOptions = null);
        Task<PasswordResetTokenResponse> GetPasswordResetToken(string id, RequestOptions? requestOptions = null);
        Task ResetPassword(string id, ResetUserPasswordData data, RequestOptions? requestOptions = null);
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
            ICryptlexAccessTokenFactory tokenFactory,
            ICurrentUserService currentUserService)
            : base(httpClientFactory, tokenFactory)
        {
            Current = currentUserService;
        }

        public async Task<IEnumerable<User>> ListAsync(ListUsersData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<User> CreateAsync(CreateUserData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<User> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<User> UpdateAsync(string id, UpdateUserData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }

        public async Task ExportAllAsync(RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Export);

            var result = await RequestAsync(uri, HttpMethod.Get, requestOptions: requestOptions);

            result.ThrowIfFailed($"Could not export all users.");
        }

        public async Task UpdatePassword(string id, UpdateUserPasswordData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.UpdatePassword);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not update password for user with id {id}.");
        }

        public async Task<PasswordResetTokenResponse> GetPasswordResetToken(string id, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.GetPasswordResetToken);

            var result = await RequestAsync(uri, HttpMethod.Post, requestOptions: requestOptions);

            result.ThrowIfFailed($"Could not get password reset token for user with id {id}.");

            var resultData = await result.ExtractDataAsync<PasswordResetTokenResponse>();

            return resultData;
        }

        public async Task ResetPassword(string id, ResetUserPasswordData data, RequestOptions? requestOptions = null)
        {
            var uri = Utils.CombinePaths(BasePath, id, Actions.ResetPassword);

            var result = await RequestAsync(uri, HttpMethod.Post, data, requestOptions);

            result.ThrowIfFailed($"Could not reset password for user with id {id}.");
        }
    }
}
