using System.Text.Json.Serialization;
namespace Cryptlex.Net.Entities
{
    public class Plan
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
		[JsonPropertyName("interval")]
        public string? Interval { get; set; }
		[JsonPropertyName("allowedUsers")]
        public int AllowedUsers { get; set; }
		[JsonPropertyName("allowedAdmins")]
        public int AllowedAdmins { get; set; }
		[JsonPropertyName("allowedProducts")]
        public int AllowedProducts { get; set; }
		[JsonPropertyName("allowedMeterAttributes")]
        public int AllowedMeterAttributes { get; set; }
		[JsonPropertyName("allowedFeatureFlags")]
        public int AllowedFeatureFlags { get; set; }
		[JsonPropertyName("allowedActivations")]
        public int AllowedActivations { get; set; }
		[JsonPropertyName("allowedTrialActivations")]
        public int AllowedTrialActivations { get; set; }
		[JsonPropertyName("allowedReleases")]
        public int AllowedReleases { get; set; }
		[JsonPropertyName("allowedProductSpace")]
        public int AllowedProductSpace { get; set; }
		[JsonPropertyName("allowedSendingDomains")]
        public int AllowedSendingDomains { get; set; }
		[JsonPropertyName("amount")]
        public string? Amount { get; set; }
		[JsonPropertyName("allowCustomerPortalAccess")]
        public bool AllowCustomerPortalAccess { get; set; }
		[JsonPropertyName("allowOfflineActivations")]
        public bool AllowOfflineActivations { get; set; }
		[JsonPropertyName("allowHostedFloatingLicenses")]
        public bool AllowHostedFloatingLicenses { get; set; }
		[JsonPropertyName("allowOnPremiseFloatingLicenses")]
        public bool AllowOnPremiseFloatingLicenses { get; set; }
		[JsonPropertyName("allowCustomDomain")]
        public bool AllowCustomDomain { get; set; }
		[JsonPropertyName("allowSso")]
        public bool AllowSso { get; set; }
		[JsonPropertyName("allowCustomRoles")]
        public bool AllowCustomRoles { get; set; }
		[JsonPropertyName("allowEventLogs")]
        public bool AllowEventLogs { get; set; }
		[JsonPropertyName("allowCustomEmailTemplates")]
        public bool AllowCustomEmailTemplates { get; set; }
		[JsonPropertyName("deprecated")]
        public bool Deprecated { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}