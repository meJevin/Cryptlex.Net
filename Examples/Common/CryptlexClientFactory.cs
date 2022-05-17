using Cryptlex.Net.Core;
using Cryptlex.Net.Core.Services;
using Microsoft.Extensions.Options;

public class HttpClientFactory : IHttpClientFactory
{
    public HttpClient CreateClient(string name)
    {
        var client = new HttpClient();
        return client;
    }
}

/// <summary>
/// When you're not using a DI container, you can instantiate CryptlexClient by hand, as shown in this factory
/// </summary>
public static class CryptlexClientFactory
{
    public static ICryptlexClient Create(CryptlexClientSettings settings)
    {
        var cryptlexClientSettings = settings;

        var httpClientFactory = new HttpClientFactory();
        var options = Options.Create(cryptlexClientSettings);

        var currentUser = new CurrentUserService(httpClientFactory, options);
        var users = new UsersService(httpClientFactory, options, currentUser);
        var roles = new RolesService(httpClientFactory, options);

        var accounts = new AccountsService(httpClientFactory, options);

        var accessTokens = new AccessTokensService(httpClientFactory, options);

        var licensePolicies = new LicensePoliciesService(httpClientFactory, options);
        var trialPolicies = new TrialPoliciesService(httpClientFactory, options);

        var products = new ProductsService(httpClientFactory, options);
        var featureFlags = new FeatureFlagsService(httpClientFactory, options);
        var productVersions = new ProductVersionsService(httpClientFactory, options);

        var releases = new ReleasesService(httpClientFactory, options);
        var releaseFiles = new ReleaseFilesService(httpClientFactory, options);

        var licenses = new LicensesService(httpClientFactory, options);
        var activations = new ActivationsService(httpClientFactory, options);
        var tags = new TagsService(httpClientFactory, options);

        var trialActivations = new TrialActivationsService(httpClientFactory, options);
        
        var webhooks = new WebhooksService(httpClientFactory, options);

        var client = new CryptlexClient(
            users, roles, accounts, accessTokens, licensePolicies,
            trialPolicies, products, featureFlags, productVersions,
            releases, releaseFiles, licenses, activations, tags, trialActivations,
            webhooks);

        return client;
    }
}