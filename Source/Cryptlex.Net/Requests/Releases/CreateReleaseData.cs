using System.Text.Json.Serialization;
namespace Cryptlex.Net.Releases
{
    public class CreateReleaseData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("version")]
        public string Version { get; set; }
		[JsonPropertyName("channel")]
        public string Channel { get; set; }
		[JsonPropertyName("platform")]
        public string Platform { get; set; }
		[JsonPropertyName("@private")]
        public bool? @private { get; set; }
		[JsonPropertyName("notes")]
        public string? Notes { get; set; }
		[JsonPropertyName("productId")]
        public string ProductId { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }

        public CreateReleaseData(
            string name, string version, string channel,
            string platform, string productId)
        {
            this.Name = name;
            this.Version = version;
            this.Channel = channel;
            this.Platform = platform;
            this.ProductId = productId;
        }
    }
}