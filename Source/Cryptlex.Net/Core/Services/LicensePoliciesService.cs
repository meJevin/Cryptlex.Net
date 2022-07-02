using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.LicensePolicies;
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
    public interface ILicensePoliciesService :
        IListable<LicensePolicy, ListLicensePoliciesData>,
        ICreatable<LicensePolicy, CreateLicensePolicyData>,
        IRetrievable<LicensePolicy>,
        IUpdatable<LicensePolicy, UpdateLicensePolicyData>,
        IDeletable<LicensePolicy>
    {
    }

    public class LicensePoliciesService : BaseService<LicensePolicy>, ILicensePoliciesService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.LicensePolicies);

        public LicensePoliciesService(
            IHttpClientFactory httpClientFactory, 
            IOptions<CryptlexClientSettings> cryptlexSettings) 
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<LicensePolicy>> ListAsync(ListLicensePoliciesData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<LicensePolicy> ListAutoPagingAsync(ListLicensePoliciesData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<LicensePolicy> CreateAsync(CreateLicensePolicyData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<LicensePolicy> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<LicensePolicy> UpdateAsync(string id, UpdateLicensePolicyData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }
    }
}
