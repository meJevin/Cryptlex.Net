using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Cryptlex.Net.Entities
{
    public class User
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("firstName")]
        public string? FirstName { get; set; }
		[JsonPropertyName("lastName")]
        public string? LastName { get; set; }
		[JsonPropertyName("email")]
        public string? Email { get; set; }
		[JsonPropertyName("company")]
        public string? Company { get; set; }
		[JsonPropertyName("twoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }
		[JsonPropertyName("googleSsoEnabled")]
        public bool GoogleSsoEnabled { get; set; }
		[JsonPropertyName("allowCustomerPortalAccess")]
        public bool AllowCustomerPortalAccess { get; set; }
		[JsonPropertyName("role")]
        public string? Role { get; set; }
		[JsonPropertyName("roles")]
        public List<string>? Roles { get; set; }
		[JsonPropertyName("lastLoginAt")]
        public DateTime? LastLoginAt { get; set; }
		[JsonPropertyName("lastSeenAt")]
        public DateTime? LastSeenAt { get; set; }
		[JsonPropertyName("metadata")]
        public List<Metadata>? Metadata { get; set; }
		[JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }
    }
}