using System.Text.Json.Serialization;
namespace Cryptlex.Net.Releases
{
    public class UpdateReleaseData
    {
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("version")]
        public string? Version { get; set; }
		[JsonPropertyName("channel")]
        public string? Channel { get; set; }
		[JsonPropertyName("platform")]
        public string? Platform { get; set; }
		[JsonPropertyName("@private")]
        public bool? @private { get; set; }
		[JsonPropertyName("notes")]
        public string? Notes { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }
    }
}