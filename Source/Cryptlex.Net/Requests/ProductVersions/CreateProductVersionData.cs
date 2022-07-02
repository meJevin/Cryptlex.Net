using System.Text.Json.Serialization;
using Cryptlex.Net.Products;

namespace Cryptlex.Net.ProductVersions
{
    public class CreateProductVersionData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
		[JsonPropertyName("description")]
        public string Description { get; set; }
		[JsonPropertyName("productId")]
        public string ProductId { get; set; }
		[JsonPropertyName("featureFlags")]
        public List<ProductVersionFeatureFlagRequestModel>? FeatureFlags { get; set; }

        public CreateProductVersionData(
            string name, string displayName, 
            string description, string productId)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.Description = description;
            this.ProductId = productId;
        }
    }
}