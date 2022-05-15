using Cryptlex.Net.Core;
using Cryptlex.Net.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtentions
    {
        public static IServiceCollection AddCryptlexClient(
            this IServiceCollection services, 
            Action<CryptlexClientSettings> configureOptions)
        {
            services.AddOptions();

            services.Configure(configureOptions);

            services.AddHttpClient();

            // General client
            services.AddScoped<ICryptlexClient, CryptlexClient>();

            // Separate services
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRolesService, RolesService>();

            services.AddScoped<IAccountsService, AccountsService>();

            services.AddScoped<IAccessTokensService, AccessTokensService>();

            services.AddScoped<ILicensePoliciesService, LicensePoliciesService>();
            services.AddScoped<ITrialPoliciesService, TrialPoliciesService>();

            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IFeatureFlagsService, FeatureFlagsService>();
            services.AddScoped<IProductVersionsService, ProductVersionsService>();

            services.AddScoped<IReleasesService, ReleasesService>();
            services.AddScoped<IReleaseFilesService, ReleaseFilesService>();

            services.AddScoped<ILicensesService, LicensesService>();
            services.AddScoped<IActivationsService, ActivationsService>();
            services.AddScoped<ITagsService, TagsService>();

            services.AddScoped<ITrialActivationsService, TrialActivationsService>();

            services.AddScoped<IWebhooksService, WebhooksService>();

            return services;
        }
    }
}
