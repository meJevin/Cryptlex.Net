using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cryptlex.Net.Util
{
    public static class ObjectExtensions
    {
        public static string ToQueryString(this object obj, bool ignoreNull = true)
        {
            var options = new JsonSerializerOptions() 
            { 
                DefaultIgnoreCondition = ignoreNull ? 
                    JsonIgnoreCondition.WhenWritingNull : 
                    JsonIgnoreCondition.Never
            };

            var serialized = JsonSerializer.Serialize(obj, options);

            var deserialized = JsonSerializer
                .Deserialize<Dictionary<string, object>>(serialized, options);

            if (deserialized is null)
            {
                return String.Empty;
            }

            var KVPs = deserialized.Select(item =>
            {
                var name = Uri.EscapeDataString(item.Key);
                var value = item.Value is null ? "null" : Uri.EscapeDataString(item.Value.ToString()!);

                return $"{name}={value}";
            });

            var result = string.Join('&', KVPs);
            return result;
        }
    }
}
