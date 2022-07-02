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
        /// <summary>
        /// Configure CryptlexClient settings manually
        /// </summary>
        ICryptlexClientConfigurator WithSettings(Action<CryptlexClientSettings> cfg);

        /// <summary>
        /// Specify a custom cryptlex access token factory
        /// 
        /// <para>
        /// Note: by default Cryptlex.NET uses the <see cref="DefaultCryptlexAccessTokenFactory"/> which simply fetches token from what's provided in <see cref="CryptlexClientSettings"/>
        /// </para>
        /// </summary>
        ICryptlexClientConfigurator WithAccessTokenFactory<T>() where T : class, ICryptlexAccessTokenFactory;
    }

    public class CryptlexClientConfigurator : ICryptlexClientConfigurator
    {
        private Type? _factoryType;
        private Action<CryptlexClientSettings>? _cfg;

        private readonly IServiceCollection _services;

        public CryptlexClientConfigurator(IServiceCollection services)
        {
            _services = services;
        }

        public ICryptlexClientConfigurator WithAccessTokenFactory<T>() where T : class, ICryptlexAccessTokenFactory
        {
            _factoryType = typeof(T);
            return this;
        }

        public ICryptlexClientConfigurator WithSettings(Action<CryptlexClientSettings> cfg)
        {
            _cfg = cfg;
            return this;
        }

        public void Finish()
        {
            if (_cfg is not null)
            {
                _services.Configure(_cfg);
            }

            if (_factoryType is not null)
            {
                foreach (var service in _services.Where(a => a.ServiceType == typeof(ICryptlexAccessTokenFactory)).ToList())
                {
                    _services.Remove(service);
                }

                _services.AddSingleton(typeof(ICryptlexAccessTokenFactory), _factoryType);
            }
        }
    }
}
