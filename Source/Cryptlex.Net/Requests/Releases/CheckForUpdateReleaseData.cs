using System.Text.Json.Serialization;
namespace Cryptlex.Net.Releases
{
    public class CheckForUpdateReleaseData
    {
		[JsonPropertyName("platform")]
        public string Platform { get; set; }
		[JsonPropertyName("productId")]
        public string ProductId { get; set; }
		[JsonPropertyName("channel")]
        public string? Channel { get; set; }
		[JsonPropertyName("version")]
        public string Version { get; set; }
		[JsonPropertyName("key")]
        public string Key { get; set; }

        public CheckForUpdateReleaseData(
            string platform, string productId, 
            string version, string key)
        {
            this.Platform = platform;
            this.ProductId = productId;
            this.Version = version;
            this.Key = key;
        }
    }
}