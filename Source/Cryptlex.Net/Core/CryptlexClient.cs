using Cryptlex.Net.Core.Services;

namespace Cryptlex.Net.Core
{
    public interface ICryptlexClient
    {
        IAccountsService Accounts { get; }
        IAccessTokensService AccessTokens { get; }
        ILicensesService Licenses { get; }
        IActivationsService Activations { get; }
        ITagsService Tags { get; }
    }

    public class CryptlexClient : ICryptlexClient
    {
        public IAccountsService Accounts { get; init; }
        public IAccessTokensService AccessTokens { get; init; }
        public ILicensesService Licenses { get; init; }
        public IActivationsService Activations { get; init; }
        public ITagsService Tags { get; init; }

        public CryptlexClient(
            IAccountsService accounts, 
            IAccessTokensService accessTokens,
            ILicensesService licenses,
            IActivationsService activations,
            ITagsService tags)
        {
            Licenses = licenses;
            Activations = activations;
            Tags = tags;
            Accounts = accounts;
            AccessTokens = accessTokens;
        }
    }
}
