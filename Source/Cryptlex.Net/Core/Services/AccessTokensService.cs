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
            ICryptlexAccessTokenFactory cryptlexAccessTokenFactory)
            : base(httpClientFactory, cryptlexAccessTokenFactory)
        {

        }

        public async Task<IEnumerable<PersonalAccessToken>> ListAsync(ListPersonalAccessTokensData data)
        {
            return await base.ListEntitiesAsync(data);
        }

        public async IAsyncEnumerable<PersonalAccessToken> ListAutoPagingAsync(ListPersonalAccessTokensData data)
        {
            await foreach (var item in base.ListEntitiesAsyncEnumerator(data))
            {
                yield return item;
            }
        }

        public async Task<PersonalAccessToken> CreateAsync(CreatePersonalAccessTokenData data)
        {
            return await base.CreateEntityAsync(data);
        }

        public async Task<PersonalAccessToken> GetAsync(string id)
        {
            return await base.GetEntityAsync(id);
        }

        public async Task<PersonalAccessToken> UpdateAsync(string id, UpdatePersonalAccessTokenData data)
        {
            return await base.UpdateEntityAsync(id, data);
        }

        public async Task DeleteAsync(string id)
        {
            await base.DeleteEntityAsync(id);
        }
    }
}
