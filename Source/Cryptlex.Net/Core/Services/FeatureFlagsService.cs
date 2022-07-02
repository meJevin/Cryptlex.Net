using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.Exceptions;
using Cryptlex.Net.FeatureFlags;
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
    public interface IFeatureFlagsService :
        IListable<FeatureFlag, ListFeatureFlagsData>,
        ICreatable<FeatureFlag, CreateFeatureFlagData>,
        IRetrievable<FeatureFlag>,
        IUpdatable<FeatureFlag, UpdateFeatureFlagData>,
        IDeletable<FeatureFlag>
    {
    }

    public class FeatureFlagsService : BaseService<FeatureFlag>, IFeatureFlagsService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.FeatureFlags);

        public FeatureFlagsService(
            IHttpClientFactory httpClientFactory,
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {
        }

        public async Task<FeatureFlag> CreateAsync(CreateFeatureFlagData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }

        public async Task<FeatureFlag> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<IEnumerable<FeatureFlag>> ListAsync(ListFeatureFlagsData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<FeatureFlag> ListAutoPagingAsync(ListFeatureFlagsData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<FeatureFlag> UpdateAsync(string id, UpdateFeatureFlagData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }
    }
}
