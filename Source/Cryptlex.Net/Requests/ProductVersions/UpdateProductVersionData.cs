using System.Text.Json.Serialization;
using Cryptlex.Net.Products;

namespace Cryptlex.Net.ProductVersions
{
    public class UpdateProductVersionData
    {
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
		[JsonPropertyName("description")]
        public string? Description { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("featureFlags")]
        public List<ProductVersionFeatureFlagRequestModel>? FeatureFlags { get; set; }
    }
}