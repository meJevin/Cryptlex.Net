using Cryptlex.Net.Core.Services;

namespace Cryptlex.Net.Core
{
    public interface ICryptlexClient
    {
        IAccountsService Accounts { get; }
        IAccessTokensService AccessTokens { get; }
        ILicensePoliciesService LicensePolicies { get; }
        ITrialPoliciesService TrialPolicies { get; }
        ILicensesService Licenses { get; }
        IActivationsService Activations { get; }
        ITagsService Tags { get; }
    }

    public class CryptlexClient : ICryptlexClient
    {
        public IAccountsService Accounts { get; init; }
        public IAccessTokensService AccessTokens { get; init; }
        public ILicensePoliciesService LicensePolicies { get; init; }
        public ITrialPoliciesService TrialPolicies { get; init; }
        public ILicensesService Licenses { get; init; }
        public IActivationsService Activations { get; init; }
        public ITagsService Tags { get; init; }

        public CryptlexClient(
            IAccountsService accounts, 
            IAccessTokensService accessTokens,
            ILicensePoliciesService licensePolicies,
            ITrialPoliciesService trialPolicies,
            ILicensesService licenses,
            IActivationsService activations,
            ITagsService tags)
        {
            Accounts = accounts;
            AccessTokens = accessTokens;
            LicensePolicies = licensePolicies;
            TrialPolicies = trialPolicies;
            Licenses = licenses;
            Activations = activations;
            Tags = tags;
        }
    }
}
