using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class ProductVersion
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
		[JsonPropertyName("description")]
        public string? Description { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("featureFlags")]
        public List<FeatureFlag>? FeatureFlags { get; set; }
    }
}