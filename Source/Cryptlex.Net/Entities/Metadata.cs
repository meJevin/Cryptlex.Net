using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptlex.Net.Entities
{
    public class Metadata
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
		[JsonPropertyName("key")]
        public string? Key { get; set; }
		[JsonPropertyName("value")]
        public string? Value { get; set; }
		[JsonPropertyName("visible")]
        public bool Visible { get; set; }
    }
}