using System.Text.Json.Serialization;
namespace Cryptlex.Net.Users
{
    public class ListUsersData : IListRequest
    {
		[JsonPropertyName("page")]
        public int? Page { get; set; }
		[JsonPropertyName("limit")]
        public int? Limit { get; set; }
		[JsonPropertyName("sort")]
        public string? Sort { get; set; }
		[JsonPropertyName("role")]
        public string? Role { get; set; }
		[JsonPropertyName("userType")]
        public string? UserType { get; set; }
		[JsonPropertyName("email")]
        public string? Email { get; set; }
		[JsonPropertyName("company{")]
        public string? company{ get; set; }
		[JsonPropertyName("tag")]
        public string? Tag { get; set; }
		[JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }
		[JsonPropertyName("metadataKey")]
        public string? MetadataKey { get; set; }
		[JsonPropertyName("metadataValue")]
        public string? MetadataValue { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("activationAppVersion")]
        public string? ActivationAppVersion { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }
		[JsonPropertyName("lastSeenAt")]
        public DateTime? LastSeenAt { get; set; }
		[JsonPropertyName("query")]
        public string? Query { get; set; }
    }
}