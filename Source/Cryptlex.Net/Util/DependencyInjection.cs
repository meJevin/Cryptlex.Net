using Cryptlex.Net.Core;
using Cryptlex.Net.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddScoped<ILicensesService, LicensesService>();
            services.AddScoped<IActivationsService, ActivationsService>();
            services.AddScoped<ITagsService, TagsService>();

            return services;
        }
    }
}
