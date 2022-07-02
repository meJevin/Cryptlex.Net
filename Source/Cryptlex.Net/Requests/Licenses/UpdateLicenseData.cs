using System.Text.Json.Serialization;
using Cryptlex.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Licenses
{
    public class UpdateLicenseData
    {
		[JsonPropertyName("key")]
        public string? Key { get; set; }
		[JsonPropertyName("revoked")]
        public bool? Revoked { get; set; }
		[JsonPropertyName("suspended")]
        public bool? Suspended { get; set; }
		[JsonPropertyName("fingerprintMatchingStrategy")]
        public string? FingerprintMatchingStrategy { get; set; }
		[JsonPropertyName("allowedActivations")]
        public int? AllowedActivations { get; set; }
		[JsonPropertyName("allowedDeactivations")]
        public int? AllowedDeactivations { get; set; }
		[JsonPropertyName("leaseDuration")]
        public int? LeaseDuration { get; set; }
		[JsonPropertyName("allowClientLeaseDuration")]
        public bool? AllowClientLeaseDuration { get; set; }
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
		[JsonPropertyName("allowVmActivation")]
        public bool? AllowVmActivation { get; set; }
		[JsonPropertyName("allowContainerActivation")]
        public bool? AllowContainerActivation { get; set; }
		[JsonPropertyName("requireAuthentication")]
        public bool? RequireAuthentication { get; set; }
		[JsonPropertyName("disableGeoLocation")]
        public bool? DisableGeoLocation { get; set; }
		[JsonPropertyName("notes")]
        public string? Notes { get; set; }
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
		[JsonPropertyName("userId")]
        public string? UserId { get; set; }
		[JsonPropertyName("resellerId")]
        public string? ResellerId { get; set; }
		[JsonPropertyName("additionalUserIds")]
        public List<string>? AdditionalUserIds { get; set; }
		[JsonPropertyName("productVersionId")]
        public string? ProductVersionId { get; set; }
		[JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }
		[JsonPropertyName("metadata")]
        public List<LicenseMetadataRequestModel>? Metadata { get; set; }
		[JsonPropertyName("meterAttributes")]
        public List<LicenseMeterAttributeRequestModel>? MeterAttributes { get; set; }    
    }
}