using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class TrialPolicy
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("allowVmActivation")]
        public bool AllowVmActivation { get; set; }
		[JsonPropertyName("allowContainerActivation")]
        public bool AllowContainerActivation { get; set; }
		[JsonPropertyName("userLocked")]
        public bool UserLocked { get; set; }
		[JsonPropertyName("disableGeoLocation")]
        public bool DisableGeoLocation { get; set; }
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
        public int TrialLength { get; set; }
        /// <summary>
        /// "fuzzy" "exact" "loose"
        /// </summary>
		[JsonPropertyName("fingerprintMatchingStrategy")]
        public string? FingerprintMatchingStrategy { get; set; }
    }
}