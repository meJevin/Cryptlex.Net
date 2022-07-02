using System.Text.Json.Serialization;
namespace Cryptlex.Net.Products
{
    public class ListProductsData : IListRequest
    {
		[JsonPropertyName("page")]
        public int? Page { get; set; }
		[JsonPropertyName("limit")]
        public int? Limit { get; set; }
		[JsonPropertyName("sort")]
        public string? Sort { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("metadataKey")]
        public string? MetadataKey { get; set; }
		[JsonPropertyName("metadataValue")]
        public string? MetadataValue { get; set; }
		[JsonPropertyName("query")]
        public string? Query { get; set; }
    }
}