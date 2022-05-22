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
            ICryptlexAccessTokenFactory tokenFactory) 
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<IEnumerable<LicensePolicy>> ListAsync(ListLicensePoliciesData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<LicensePolicy> CreateAsync(CreateLicensePolicyData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<LicensePolicy> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<LicensePolicy> UpdateAsync(string id, UpdateLicensePolicyData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }
    }
}
