using System.Text.Json.Serialization;
namespace Cryptlex.Net.TrialPolicies
{
    public class UpdateTrialPolicyData
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
		[JsonPropertyName("trialLength")]
        public int? TrialLength { get; set; }                                        
    }
}