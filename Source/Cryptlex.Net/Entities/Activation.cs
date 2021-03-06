using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Cryptlex.Net.Entities
{
    public class Activation
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
        /// <summary>
        /// "windows" "linux" "macos" "android" "ios"
        /// </summary>
		[JsonPropertyName("os")]
        public string? Os { get; set; }
		[JsonPropertyName("osVersion")]
        public string? OsVersion { get; set; }
		[JsonPropertyName("hostname")]
        public string? Hostname { get; set; }
		[JsonPropertyName("location")]
        public Location Location { get; set; }
		[JsonPropertyName("vmName")]
        public string? VmName { get; set; }
		[JsonPropertyName("container")]
        public bool Container { get; set; }
		[JsonPropertyName("offline")]
        public bool Offline { get; set; }
		[JsonPropertyName("appVersion")]
        public string? AppVersion { get; set; }
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("expiresAt")]
        public DateTime? ExpiresAt { get; set; }
        [JsonPropertyName("releaseVersion")]
        public string? ReleaseVersion { get; set; }
        [JsonPropertyName("metadata")]
        public List<ActivationMetadata>? Metadata { get; set; }
		[JsonPropertyName("licenseId")]
        public string? LicenseId { get; set; }
		[JsonPropertyName("lastSyncedAt")]
        public DateTime? LastSyncedAt { get; set; }
		[JsonPropertyName("leaseExpiresAt")]
        public DateTime? LeaseExpiresAt { get; set; }
		[JsonPropertyName("meterAttributes")]
        public List<ActivationMeterAttribute>? MeterAttributes { get; set; }
    }
}