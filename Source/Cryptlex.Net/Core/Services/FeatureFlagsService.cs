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
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {
        }

        public async Task<FeatureFlag> CreateAsync(CreateFeatureFlagData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }

        public async Task<FeatureFlag> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<IEnumerable<FeatureFlag>> ListAsync(ListFeatureFlagsData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<FeatureFlag> UpdateAsync(string id, UpdateFeatureFlagData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }
    }
}
