using System.Text.Json.Serialization;
namespace Cryptlex.Net.LicensePolicies
{
    public class UpdateLicensePolicyData
    {
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("fingerprintMatchingStrategy")]
        public string? FingerprintMatchingStrategy { get; set; }
		[JsonPropertyName("allowVmActivation")]
        public bool? AllowVmActivation { get; set; }
		[JsonPropertyName("allowContainerActivation")]
        public bool? AllowContainerActivation { get; set; }
		[JsonPropertyName("userLocked")]
        public bool? UserLocked { get; set; }
		[JsonPropertyName("disableGeoLocation")]
        public bool? DisableGeoLocation { get; set; }
		[JsonPropertyName("allowedIpRange")]
        public string? AllowedIpRange { get; set; }
		[JsonPropertyName("allowedIpRanges")]
        public List<string>? AllowedIpRanges { get; set; }
		[JsonPropertyName("allowedCountries")]
        public List<string>? AllowedCountries { get; set; }
		[JsonPropertyName("disallowedCountries")]
        public List<string>? DisallowedCountries { get; set; }
		[JsonPropertyName("allowedIpAddresses")]
        public List<string>? AllowedIpAddresses { get; set; }
		[JsonPropertyName("disallowedIpAddresses")]
        public List<string>? DisallowedIpAddresses { get; set; }
		[JsonPropertyName("validity")]
        public int? Validity { get; set; }
		[JsonPropertyName("expirationStrategy")]
        public string? ExpirationStrategy { get; set; }
		[JsonPropertyName("allowedActivations")]
        public int? AllowedActivations { get; set; }
		[JsonPropertyName("allowedDeactivations")]
        public int? AllowedDeactivations { get; set; }
		[JsonPropertyName("type")]
        public string? Type { get; set; }
		[JsonPropertyName("keyPattern")]
        public string? KeyPattern { get; set; }
		[JsonPropertyName("leaseDuration")]
        public int? LeaseDuration { get; set; }
		[JsonPropertyName("allowClientLeaseDuration")]
        public bool? AllowClientLeaseDuration { get; set; }
		[JsonPropertyName("leasingStrategy")]
        public string? LeasingStrategy { get; set; }
		[JsonPropertyName("allowedFloatingClients")]
        public int? AllowedFloatingClients { get; set; }
		[JsonPropertyName("serverSyncGracePeriod")]
        public int? ServerSyncGracePeriod { get; set; }
		[JsonPropertyName("serverSyncInterval")]
        public int? ServerSyncInterval { get; set; }
		[JsonPropertyName("allowedClockOffset")]
        public int? AllowedClockOffset { get; set; }
		[JsonPropertyName("disableClockValidation")]
        public bool? DisableClockValidation { get; set; }
		[JsonPropertyName("expiringSoonEventOffset")]
        public int? ExpiringSoonEventOffset { get; set; }
		[JsonPropertyName("requireAuthentication")]
        public bool? RequireAuthentication { get; set; }
		[JsonPropertyName("requiredMetadataKeys")]
        public List<string>? RequiredMetadataKeys { get; set; }
		[JsonPropertyName("requiredMeterAttributes")]
        public List<string>? RequiredMeterAttributes { get; set; }                       
    }
}