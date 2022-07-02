using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class Webhook
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("url")]
        public string? Url { get; set; }
		[JsonPropertyName("token")]
        public string? Token { get; set; }
		[JsonPropertyName("active")]
        public bool Active { get; set; }
		[JsonPropertyName("events")]
        public List<string>? Events { get; set; }
    }
}