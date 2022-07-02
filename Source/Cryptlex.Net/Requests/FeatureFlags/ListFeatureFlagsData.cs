using System.Text.Json.Serialization;
namespace Cryptlex.Net.FeatureFlags
{
    public class ListFeatureFlagsData : IListRequest
    {
		[JsonPropertyName("page")]
        public int? Page { get; set; }
		[JsonPropertyName("limit")]
        public int? Limit { get; set; }
		[JsonPropertyName("sort")]
        public string? Sort { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("query")]
        public string? Query { get; set; }
    }
}