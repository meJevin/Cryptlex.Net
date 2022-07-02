using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class LicensePolicy
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
		[JsonPropertyName("validity")]
        public int Validity { get; set; }
        /// <summary>
        /// "immediate" "delayed" "rolling"
        /// </summary>
		[JsonPropertyName("expirationStrategy")]
        public string? ExpirationStrategy { get; set; }
        /// <summary>
        /// "fuzzy" "exact" "loose"
        /// </summary>
		[JsonPropertyName("fingerprintMatchingStrategy")]
        public string? FingerprintMatchingStrategy { get; set; }
		[JsonPropertyName("allowedActivations")]
        public int AllowedActivations { get; set; }
		[JsonPropertyName("allowedDeactivations")]
        public int AllowedDeactivations { get; set; }
        /// <summary>
        /// "node-locked" "hosted-floating" "on-premise-floating"
        /// </summary>
		[JsonPropertyName("type")]
        public string? Type { get; set; }
		[JsonPropertyName("keyPattern")]
        public string? KeyPattern { get; set; }
		[JsonPropertyName("leaseDuration")]
        public int LeaseDuration { get; set; }
		[JsonPropertyName("allowClientLeaseDuration")]
        public bool AllowClientLeaseDuration { get; set; }
        /// <summary>
        /// "per-machine" "per-instance"
        /// </summary>
		[JsonPropertyName("leasingStrategy")]
        public string? LeasingStrategy { get; set; }
		[JsonPropertyName("allowedFloatingClients")]
        public int AllowedFloatingClients { get; set; }
		[JsonPropertyName("serverSyncGracePeriod")]
        public int ServerSyncGracePeriod { get; set; }
		[JsonPropertyName("serverSyncInterval")]
        public int ServerSyncInterval { get; set; }
		[JsonPropertyName("allowedClockOffset")]
        public int AllowedClockOffset { get; set; }
		[JsonPropertyName("disableClockValidation")]
        public bool DisableClockValidation { get; set; }
		[JsonPropertyName("expiringSoonEventOffset")]
        public int ExpiringSoonEventOffset { get; set; }
		[JsonPropertyName("requireAuthentication")]
        public bool RequireAuthentication { get; set; }
		[JsonPropertyName("requiredMetadataKeys")]
        public List<string>? RequiredMetadataKeys { get; set; }
		[JsonPropertyName("requiredMeterAttributes")]
        public List<string>? RequiredMeterAttributes { get; set; }
    }
}