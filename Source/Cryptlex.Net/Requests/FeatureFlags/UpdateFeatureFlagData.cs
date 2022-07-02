using System.Text.Json.Serialization;
namespace Cryptlex.Net.FeatureFlags
{
    public class UpdateFeatureFlagData
    {
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("description")]
        public string? Description { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
    }
}