using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.TrialPolicies;
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
    public interface ITrialPoliciesService :
        IListable<TrialPolicy, ListTrialPoliciesData>,
        ICreatable<TrialPolicy, CreateTrialPolicyData>,
        IRetrievable<TrialPolicy>,
        IUpdatable<TrialPolicy, UpdateTrialPolicyData>,
        IDeletable<TrialPolicy>
    {
    }

    public class TrialPoliciesService : BaseService<TrialPolicy>, ITrialPoliciesService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.TrialPolicies);

        public TrialPoliciesService(
            IHttpClientFactory httpClientFactory, 
            ICryptlexAccessTokenFactory tokenFactory) 
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<IEnumerable<TrialPolicy>> ListAsync(ListTrialPoliciesData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<TrialPolicy> CreateAsync(CreateTrialPolicyData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<TrialPolicy> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<TrialPolicy> UpdateAsync(string id, UpdateTrialPolicyData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }
    }
}
