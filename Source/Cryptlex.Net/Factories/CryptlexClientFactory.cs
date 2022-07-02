using Cryptlex.Net.Core;
using Cryptlex.Net.Core.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Core
{
    public class DefaultHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            var client = new HttpClient();
            return client;
        }
    }

    public static class CryptlexClientFactory
    {
        public static ICryptlexClient Create(CryptlexClientSettings settings, IHttpClientFactory? httpClientFactory = null)
        {
            var cryptlexClientSettings = settings;

            if (httpClientFactory is null)
            {
                httpClientFactory = new DefaultHttpClientFactory();
            }

            var options = Options.Create(cryptlexClientSettings);
            var defaultFactory = new DefaultCryptlexAccessTokenFactory(options);

            var currentUser = new CurrentUserService(httpClientFactory, defaultFactory);
            var users = new UsersService(httpClientFactory, defaultFactory, currentUser);
            var roles = new RolesService(httpClientFactory, defaultFactory);

            var accounts = new AccountsService(httpClientFactory, defaultFactory);

            var accessTokens = new AccessTokensService(httpClientFactory, defaultFactory);

            var licensePolicies = new LicensePoliciesService(httpClientFactory, defaultFactory);
            var trialPolicies = new TrialPoliciesService(httpClientFactory, defaultFactory);

            var products = new ProductsService(httpClientFactory, defaultFactory);
            var featureFlags = new FeatureFlagsService(httpClientFactory, defaultFactory);
            var productVersions = new ProductVersionsService(httpClientFactory, defaultFactory);

            var releases = new ReleasesService(httpClientFactory, defaultFactory);
            var releaseFiles = new ReleaseFilesService(httpClientFactory, defaultFactory);

            var licenses = new LicensesService(httpClientFactory, defaultFactory);
            var activations = new ActivationsService(httpClientFactory, defaultFactory);
            var tags = new TagsService(httpClientFactory, defaultFactory);

            var trialActivations = new TrialActivationsService(httpClientFactory, defaultFactory);

            var webhooks = new WebhooksService(httpClientFactory, defaultFactory);

            var client = new CryptlexClient(
                users, roles, accounts, accessTokens, licensePolicies,
                trialPolicies, products, featureFlags, productVersions,
                releases, releaseFiles, licenses, activations, tags, trialActivations,
                webhooks);

            return client;
        }
    }
}
