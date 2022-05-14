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
        IListable<TrialPolicy, GetAllTrialPoliciesData>,
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
            IOptions<CryptlexClientSettings> cryptlexSettings) 
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<IEnumerable<TrialPolicy>> GetAllAsync(GetAllTrialPoliciesData data)
        {
            return await base.GenericGetAllAsync(data);
        }

        public async Task<TrialPolicy> CreateAsync(CreateTrialPolicyData data)
        {
            return await base.GenericCreateAsync(data);
        }

        public async Task<TrialPolicy> GetAsync(string id)
        {
            return await base.GenericGetAsync(id);
        }

        public async Task<TrialPolicy> UpdateAsync(string id, UpdateTrialPolicyData data)
        {
            return await base.GenericUpdateAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.GenericDeleteAsync(id);
        }
    }
}
