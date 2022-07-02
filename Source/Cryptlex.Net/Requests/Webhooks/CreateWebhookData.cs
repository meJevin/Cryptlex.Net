using System.Text.Json.Serialization;
namespace Cryptlex.Net.Webhooks
{
    public class CreateWebhookData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("url")]
        public string Url { get; set; }
		[JsonPropertyName("token")]
        public string Token { get; set; }
		[JsonPropertyName("active")]
        public bool Active { get; set; }
		[JsonPropertyName("events")]
        public List<string> Events { get; set; }

        public CreateWebhookData(
            string name, string url, string token,
            bool active, List<string> events)
        {
            this.Name = name;
            this.Url = url;
            this.Token = token;
            this.Active = active;
            this.Events = events;
        }
    }
}