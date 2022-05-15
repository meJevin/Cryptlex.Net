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

        public IProductsService Products { get; init; }
        public IFeatureFlagsService FeatureFlags { get; init; }
        public IProductVersionsService ProductVersions { get; init; }

        public IReleasesService Releases { get; init; }
        public IReleaseFilesService ReleaseFiles { get; init; }

        public ILicensesService Licenses { get; init; }
        public IActivationsService Activations { get; init; }
        public ITagsService Tags { get; init; }

        public ITrialActivationsService TrialActivations { get; init; }

        public IWebhooksService Webhooks { get; init; }

        public CryptlexClient(
            IUsersService userService,
            IRolesService roleService,
            IAccountsService accounts, 
            IAccessTokensService accessTokens,
            ILicensePoliciesService licensePolicies,
            ITrialPoliciesService trialPolicies,
            IProductsService products,
            IFeatureFlagsService featureFlags,
            IProductVersionsService productVersions,
            IReleasesService releases,
            IReleaseFilesService releaseFiles,
            ILicensesService licenses,
            IActivationsService activations,
            ITagsService tags,
            ITrialActivationsService trialActivations,
            IWebhooksService webhooksService)
        {
            UserService = userService;
            RoleService = roleService;
            Accounts = accounts;
            AccessTokens = accessTokens;
            LicensePolicies = licensePolicies;
            TrialPolicies = trialPolicies;
            Products = products;
            FeatureFlags = featureFlags;
            ProductVersions = productVersions;
            Releases = releases;
            ReleaseFiles = releaseFiles;
            Licenses = licenses;
            Activations = activations;
            Tags = tags;
            TrialActivations = trialActivations;
            Webhooks = webhooksService;
        }
    }
}
