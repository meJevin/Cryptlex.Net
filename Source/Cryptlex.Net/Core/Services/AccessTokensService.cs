using Cryptlex.Net.Core.Services.Base;
using Cryptlex.Net.Entities;
using Cryptlex.Net.PersonalAccessTokens;
using Cryptlex.Net.Util;
using Microsoft.Extensions.Options;

namespace Cryptlex.Net.Core.Services
{
    public interface IAccessTokensService :
        IListable<PersonalAccessToken, GetAllPersonalAccessTokensData>,
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
            IOptions<CryptlexClientSettings> cryptlexSettings)
            : base(httpClientFactory, cryptlexSettings)
        {

        }

        public async Task<IEnumerable<PersonalAccessToken>> GetAllAsync(GetAllPersonalAccessTokensData data)
        {
            return await base.GenericGetAllAsync(data);
        }

        public async Task<PersonalAccessToken> CreateAsync(CreatePersonalAccessTokenData data)
        {
            return await base.GenericCreateAsync(data);
        }

        public async Task<PersonalAccessToken> GetAsync(string id)
        {
            return await base.GenericGetAsync(id);
        }

        public async Task<PersonalAccessToken> UpdateAsync(string id, UpdatePersonalAccessTokenData data)
        {
            return await base.GenericGetAsync(id);
        }

        public async Task DeleteAsync(string id)
        {
            await base.GenericDeleteAsync(id);
        }
    }
}
