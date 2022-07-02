using System;
using System.Collections.Generic;

namespace Cryptlex.Net.Entities
{
    public class License
    {
        public string? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Key { get; set; }
        public bool Revoked { get; set; }
        public bool Suspended { get; set; }
        public int TotalActivations { get; set; }
        public int TotalDeactivations { get; set; }
        public int Validity { get; set; }
        /// <summary>
        /// "immediate" "delayed" "rolling"
        /// </summary>
        public string? ExpirationStrategy { get; set; }
        /// <summary>
        /// "fuzzy" "exact" "loose"
        /// </summary>
        public string? FingerprintMatchingStrategy { get; set; }
        public int AllowedActivations { get; set; }
        public int AllowedDeactivations { get; set; }
        /// <summary>
        /// "node-locked" "hosted-floating" "on-premise-floating"
        /// </summary>
        public string? Type { get; set; }
        public int AllowedFloatingClients { get; set; }
        public int ServerSyncGracePeriod { get; set; }
        public int ServerSyncInterval { get; set; }
        public int AllowedClockOffset { get; set; }
        public int ExpiringSoonEventOffset { get; set; }
        public int LeaseDuration { get; set; }
        /// <summary>
        /// "per-machine" "per-instance"
        /// </summary>
        public string? LeasingStrategy { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public bool AllowVmActivation { get; set; }
        public bool AllowContainerActivation { get; set; }
        public bool UserLocked { get; set; }
        public bool RequireAuthentication { get; set; }
        public bool DisableGeoLocation { get; set; }
        public string? Notes { get; set; }
        public string? ProductId { get; set; }
        public string? ProductVersionId { get; set; }
        public User User { get; set; }
        public User Reseller { get; set; }
        public List<string>? AdditionalUserIds { get; set; }
        public string? AllowedIpRange { get; set; }
        public List<string>? AllowedIpRanges { get; set; }
        public List<string>? AllowedIpAddresses { get; set; }
        public List<string>? DisallowedIpAddresses { get; set; }
        public List<string>? AllowedCountries { get; set; }
        public List<string>? DisallowedCountries { get; set; }
        public List<Metadata>? Metadata { get; set; }
        public List<LicenseMeterAttribute>? MeterAttributes { get; set; }
        public List<string>? Tags { get; set; }
    }
}