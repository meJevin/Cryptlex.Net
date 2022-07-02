using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class ReleaseFile
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
		[JsonPropertyName("size")]
        public int Size { get; set; }
		[JsonPropertyName("downloads")]
        public int Downloads { get; set; }
		[JsonPropertyName("extension")]
        public string? Extension { get; set; }
		[JsonPropertyName("checksum")]
        public string? Checksum { get; set; }
		[JsonPropertyName("secured")]
        public bool Secured { get; set; }
		[JsonPropertyName("releaseId")]
        public string? ReleaseId { get; set; }
    }
}