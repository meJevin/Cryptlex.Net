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
        IListable<Role, GetAllRolesData>,
        ICreatable<Role, CreateRoleData>,
        IRetrievable<Role>,
        IUpdatable<Role, UpdateRoleData>,
        IDeletable<Role>
    {
        Task<IEnumerable<string>> GetAllClaims(GetAllRoleClaimsData data);
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

        public async Task<IEnumerable<Role>> GetAllAsync(GetAllRolesData data)
        {
            return await base.GenericGetAllAsync(data);
        }

        public async Task<IEnumerable<string>> GetAllClaims(GetAllRoleClaimsData data)
        {
            var uri = Utils.CombinePaths(BasePath, Actions.Claims);

            return await base.GenericGetAllAsync<string, GetAllRoleClaimsData>(data, uri);
        }

        public async Task<Role> CreateAsync(CreateRoleData data)
        {
            return await base.GenericCreateAsync(data);
        }

        public async Task<Role> GetAsync(string id)
        {
            return await base.GenericGetAsync(id);
        }

        public async Task<Role> UpdateAsync(string id, UpdateRoleData data)
        {
            return await base.GenericUpdateAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.GenericDeleteAsync(id);
        }
    }
}
