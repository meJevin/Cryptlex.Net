using System.Text.Json.Serialization;
namespace Cryptlex.Net.Webhooks
{
    public class UpdateWebhookData
    {
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("url")]
        public string? Url { get; set; }
		[JsonPropertyName("token")]
        public string? Token { get; set; }
		[JsonPropertyName("active")]
        public bool? Active { get; set; }
		[JsonPropertyName("events")]
        public List<string>? Events { get; set; }    
    }
}