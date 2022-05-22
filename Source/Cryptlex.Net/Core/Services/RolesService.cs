using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.Roles;
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
    public interface IRolesService :
        IListable<Role, ListRolesData>,
        ICreatable<Role, CreateRoleData>,
        IRetrievable<Role>,
        IUpdatable<Role, UpdateRoleData>,
        IDeletable<Role>
    {
        Task<IEnumerable<string>> ListClaims(ListRoleClaimsData data, RequestOptions? requestOptions = null);
    }

    public class RolesService : BaseService<Role>, IRolesService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.Roles);

        public static class Actions
        {
            public static string Claims = "claims";
        }

        public RolesService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<IEnumerable<Role>> ListAsync(ListRolesData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<IEnumerable<string>> ListClaims(ListRoleClaimsData data, RequestOptions? requestOptions = null)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Get, data, requestOptions);

            result.ThrowIfFailed($"Could not get all claims.");

            var resultData = await result.ExtractDataAsync<IEnumerable<string>>();

            return resultData;
        }

        public async Task<Role> CreateAsync(CreateRoleData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<Role> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<Role> UpdateAsync(string id, UpdateRoleData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }
    }
}
