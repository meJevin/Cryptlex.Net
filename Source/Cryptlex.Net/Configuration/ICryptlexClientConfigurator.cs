using Cryptlex.Net.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Configuration
{
    public interface ICryptlexClientConfigurator
    {
        void WithSettings(Action<CryptlexClientSettings> cfg);

        void WithAccessTokenFactory<T>() where T : class, ICryptlexAccessTokenFactory;
    }

    public class CryptlexClientConfigurator : ICryptlexClientConfigurator
    {
        private readonly IServiceCollection services;

        public CryptlexClientConfigurator(IServiceCollection services)
        {
            this.services = services;
        }

        public void WithAccessTokenFactory<T>() where T : class, ICryptlexAccessTokenFactory
        {
            foreach (var service in services.Where(a => a.ServiceType == typeof(ICryptlexAccessTokenFactory)).ToList())
            {
                services.Remove(service);
            }

            services.AddSingleton<ICryptlexAccessTokenFactory, T>();
        }

        public void WithSettings(Action<CryptlexClientSettings> cfg)
        {
            services.Configure(cfg);
        }
    }
}
