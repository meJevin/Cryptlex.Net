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
            ICryptlexAccessTokenFactory cryptlexAccessTokenFactory)
            : base(httpClientFactory, cryptlexAccessTokenFactory)
        {
        }

        public async Task<IEnumerable<TrialPolicy>> ListAsync(ListTrialPoliciesData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<TrialPolicy> ListAutoPagingAsync(ListTrialPoliciesData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<TrialPolicy> CreateAsync(CreateTrialPolicyData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<TrialPolicy> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<TrialPolicy> UpdateAsync(string id, UpdateTrialPolicyData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }
    }
}
