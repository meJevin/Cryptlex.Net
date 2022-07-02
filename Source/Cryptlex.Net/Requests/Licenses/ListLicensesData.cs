using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Licenses
{
    public class ListLicensesData : IListRequest
    {
		[JsonPropertyName("page")]
        public int? Page { get; set; }
		[JsonPropertyName("limit")]
        public int? Limit { get; set; }
		[JsonPropertyName("sort")]
        public string? Sort { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("userId")]
        public string? UserId { get; set; }
		[JsonPropertyName("resellerId")]
        public string? ResellerId { get; set; }
		[JsonPropertyName("userEmail")]
        public string? UserEmail { get; set; }
		[JsonPropertyName("userCompany")]
        public string? UserCompany { get; set; }
		[JsonPropertyName("key")]
        public string? Key { get; set; }
		[JsonPropertyName("revoked")]
        public bool? Revoked { get; set; }
		[JsonPropertyName("suspended")]
        public bool? Suspended { get; set; }
		[JsonPropertyName("type")]
        public string? Type { get; set; }
		[JsonPropertyName("validity")]
        public int? Validity { get; set; }
		[JsonPropertyName("allowedActivations")]
        public int? AllowedActivations { get; set; }
		[JsonPropertyName("allowedDeactivations")]
        public int? AllowedDeactivations { get; set; }
		[JsonPropertyName("totalActivations")]
        public int? TotalActivations { get; set; }
		[JsonPropertyName("totalDeactivations")]
        public int? TotalDeactivations { get; set; }
		[JsonPropertyName("allowVmActivation")]
        public bool? AllowVmActivation { get; set; }
		[JsonPropertyName("userLocked")]
        public bool? UserLocked { get; set; }
		[JsonPropertyName("expired")]
        public bool? Expired { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }
		[JsonPropertyName("tag")]
        public string? Tag { get; set; }
		[JsonPropertyName("metadataKey")]
        public string? MetadataKey { get; set; } 
		[JsonPropertyName("metadataValue")]
        public string? MetadataValue { get; set; }
		[JsonPropertyName("query")]
        public string? Query { get; set; }                                                               
    }
}