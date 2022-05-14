using Cryptlex.Net.Core.Services;

namespace Cryptlex.Net.Core
{
    public interface ICryptlexClient
    {
        IUsersService UserService { get; }
        IRolesService RoleService { get; }
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
        public IUsersService UserService { get; init; }
        public IRolesService RoleService { get; init; }
        public IAccountsService Accounts { get; init; }
        public IAccessTokensService AccessTokens { get; init; }
        public ILicensePoliciesService LicensePolicies { get; init; }
        public ITrialPoliciesService TrialPolicies { get; init; }
        public ILicensesService Licenses { get; init; }
        public IActivationsService Activations { get; init; }
        public ITagsService Tags { get; init; }

        public CryptlexClient(
            IUsersService userService,
            IRolesService roleService,
            IAccountsService accounts, 
            IAccessTokensService accessTokens,
            ILicensePoliciesService licensePolicies,
            ITrialPoliciesService trialPolicies,
            ILicensesService licenses,
            IActivationsService activations,
            ITagsService tags)
        {
            UserService = userService;
            RoleService = roleService;
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
