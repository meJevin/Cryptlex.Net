using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class PersonalAccessToken
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("expiresAt")]
        public DateTime? ExpiresAt { get; set; }
		[JsonPropertyName("revoked")]
        public bool Revoked { get; set; }
		[JsonPropertyName("scopes")]
        public List<string>? Scopes { get; set; }
    }
}