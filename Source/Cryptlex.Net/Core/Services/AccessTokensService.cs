using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.PersonalAccessTokens;
using Cryptlex.Net.Util;
using Microsoft.Extensions.Options;

namespace Cryptlex.Net.Core.Services
{
    public interface IAccessTokensService :
        IListable<PersonalAccessToken, ListPersonalAccessTokensData>,
        ICreatable<PersonalAccessToken, CreatePersonalAccessTokenData>,
        IRetrievable<PersonalAccessToken>,
        IUpdatable<PersonalAccessToken, UpdatePersonalAccessTokenData>,
        IDeletable<PersonalAccessToken>
    {

    }

    public class AccessTokensService : BaseService<PersonalAccessToken>, IAccessTokensService
    {
        protected override string BasePath => Utils.CombinePaths(API.Version, API.Paths.PersonalAccessTokens);

        public AccessTokensService(
            IHttpClientFactory httpClientFactory,
            ICryptlexAccessTokenFactory tokenFactory)
            : base(httpClientFactory, tokenFactory)
        {

        }

        public async Task<IEnumerable<PersonalAccessToken>> ListAsync(ListPersonalAccessTokensData data, RequestOptions? requestOptions = null)
        {
            return await base.ListEntitiesAsync(data, requestOptions);
        }

        public async Task<PersonalAccessToken> CreateAsync(CreatePersonalAccessTokenData data, RequestOptions? requestOptions = null)
        {
            return await base.CreateEntityAsync(data, requestOptions);
        }

        public async Task<PersonalAccessToken> GetAsync(string id, RequestOptions? requestOptions = null)
        {
            return await base.GetEntityAsync(id, requestOptions);
        }

        public async Task<PersonalAccessToken> UpdateAsync(string id, UpdatePersonalAccessTokenData data, RequestOptions? requestOptions = null)
        {
            return await base.UpdateEntityAsync(id, data, requestOptions);
        }

        public async Task DeleteAsync(string id, RequestOptions? requestOptions = null)
        {
            await base.DeleteEntityAsync(id, requestOptions);
        }
    }
}
