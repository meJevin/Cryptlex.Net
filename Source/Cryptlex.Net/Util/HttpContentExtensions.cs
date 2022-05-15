using Cryptlex.Net.Entities;
using System.Text.Json;

namespace Cryptlex.Net.Util
{
    public static class HttpContentExtensions
    {
        public static async Task<Error?> ReadCryptlexErrorAsync(this HttpContent content)
        {
            return JsonSerializer.Deserialize<Error>(await content.ReadAsStringAsync());
        }
    }
}
