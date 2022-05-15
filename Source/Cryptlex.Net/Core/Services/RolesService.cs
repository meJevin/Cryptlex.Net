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
        Task<IEnumerable<string>> ListClaims(ListRoleClaimsData data);
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
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<Role>> ListAsync(ListRolesData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async Task<IEnumerable<string>> ListClaims(ListRoleClaimsData data)
        {
            var uri = BasePath;

            var result = await RequestAsync(uri, HttpMethod.Get, data);

            result.ThrowIfFailed($"Could not get all claims.");

            var resultData = await result.ContentToAsync<IEnumerable<string>>();

            return resultData;
        }

        public async Task<Role> CreateAsync(CreateRoleData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<Role> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<Role> UpdateAsync(string id, UpdateRoleData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }
    }
}
