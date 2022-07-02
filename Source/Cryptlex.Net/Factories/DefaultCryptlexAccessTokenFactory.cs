using Cryptlex.Net.Core;
using Microsoft.Extensions.Options;

namespace Cryptlex.Net.Core
{
    public class DefaultCryptlexAccessTokenFactory : ICryptlexAccessTokenFactory
    {
        private readonly CryptlexClientSettings _cryptlexSettings;

        public DefaultCryptlexAccessTokenFactory(IOptions<CryptlexClientSettings> cryptlexSettings)
        {
            _cryptlexSettings = cryptlexSettings.Value;
        }

        public Task<string> GetAccessTokenAsync()
        {
            return Task.FromResult(_cryptlexSettings.AccessToken!);
        }
    }
}
