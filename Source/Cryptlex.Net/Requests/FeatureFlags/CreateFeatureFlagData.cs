using System.Text.Json.Serialization;
namespace Cryptlex.Net.FeatureFlags
{
    public class CreateFeatureFlagData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("description")]
        public string Description { get; set; }
		[JsonPropertyName("productId")]
        public string ProductId { get; set; }

        public CreateFeatureFlagData(string name, string description, string productId)
        {
            this.Name = name;
            this.Description = description;
            this.ProductId = productId;
        }
    }
}