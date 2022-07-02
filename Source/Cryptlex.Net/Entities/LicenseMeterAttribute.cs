using System.Text.Json.Serialization;
using System;

namespace Cryptlex.Net.Entities
{
    public class LicenseMeterAttribute
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("allowedUses")]
        public int AllowedUses { get; set; }
		[JsonPropertyName("totalUses")]
        public int? TotalUses { get; set; }
		[JsonPropertyName("grossUses")]
        public int? GrossUses { get; set; }
		[JsonPropertyName("uses")]
        public int Uses { get; set; }
		[JsonPropertyName("floating")]
        public bool Floating { get; set; }
		[JsonPropertyName("visible")]
        public bool Visible { get; set; }
    }
}