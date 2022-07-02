using System.Text.Json.Serialization;
namespace Cryptlex.Net.Releases
{
    public class GetLatestReleaseData
    {
		[JsonPropertyName("platform")]
        public string Platform { get; set; }
		[JsonPropertyName("productId")]
        public string ProductId { get; set; }
		[JsonPropertyName("channel")]
        public string? Channel { get; set; }
		[JsonPropertyName("key")]
        public string Key { get; set; }

        public GetLatestReleaseData(
            string platform, string productId, string key)
        {
            this.Platform = platform;
            this.ProductId = productId;
            this.Key = key;
        }
    }
}