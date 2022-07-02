using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class ListActivationsData : IListRequest
    {
		[JsonPropertyName("page")]
        public int? Page { get; set; }
		[JsonPropertyName("limit")]
        public int? Limit { get; set; }
		[JsonPropertyName("sort")]
        public string? Sort { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("licenseId")]
        public string? LicenseId { get; set; }
		[JsonPropertyName("metadataKey")]
        public string? MetadataKey { get; set; }
		[JsonPropertyName("metadataValue")]
        public string? MetadataValue { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }
		[JsonPropertyName("lastSyncedAt")]
        public DateTime? LastSyncedAt { get; set; }
		[JsonPropertyName("query")]
        public string? Query { get; set; }                                                               
    }
}