using System.Text.Json.Serialization;
namespace Cryptlex.Net.Entities
{
    public class Account
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
		[JsonPropertyName("company")]
        public string? Company { get; set; }
		[JsonPropertyName("email")]
        public string? Email { get; set; }
        /// <summary>
        /// "active" "inactive"
        /// </summary>
		[JsonPropertyName("status")]
        public string? Status { get; set; } 
		[JsonPropertyName("customDomain")]
        public string? CustomDomain { get; set; }
		[JsonPropertyName("website")]
        public string? Website { get; set; }
		[JsonPropertyName("logoUrl")]
        public string? LogoUrl { get; set; }
		[JsonPropertyName("faviconUrl")]
        public string? FaviconUrl { get; set; }
		[JsonPropertyName("googleClientId")]
        public string? GoogleClientId { get; set; }
		[JsonPropertyName("trialExpiresAt")]
        public DateTime TrialExpiresAt { get; set; }
		[JsonPropertyName("plan")]
        public Plan Plan { get; set; }
		[JsonPropertyName("companyId")]
        public string? CompanyId { get; set; }
    }
}