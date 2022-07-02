using System.Text.Json.Serialization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class Release
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("channel")]
        public string? Channel { get; set; }
		[JsonPropertyName("version")]
        public string? Version { get; set; }
		[JsonPropertyName("platform")]
        public string? Platform { get; set; }
		[JsonPropertyName("notes")]
        public string? Notes { get; set; }
		[JsonPropertyName("totalFiles")]
        public int TotalFiles { get; set; }
		[JsonPropertyName("files")]
        public List<ReleaseFile>? Files { get; set; }
		[JsonPropertyName("published")]
        public bool Published { get; set; }
		[JsonPropertyName("@private")]
        public bool @private { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("tenantId")]
        public string? TenantId { get; set; }
    }
}