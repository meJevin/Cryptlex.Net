﻿using Cryptlex.Net.Core;
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
            services.AddScoped<ILicensesService, LicensesService>();
            services.AddScoped<IActivationsService, ActivationsService>();
            services.AddScoped<ITagsService, TagsService>();

            return services;
        }
    }
}