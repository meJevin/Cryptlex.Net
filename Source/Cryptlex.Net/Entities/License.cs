using System;
using System.Collections.Generic;

namespace Cryptlex.Net.Entities
{
    public class License
    {
        public string? id { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? key { get; set; }
        public bool revoked { get; set; }
        public bool suspended { get; set; }
        public int totalActivations { get; set; }
        public int totalDeactivations { get; set; }
        public int validity { get; set; }
        public string? expirationStrategy { get; set; } // "immediate" "delayed" "rolling"
        public string? fingerprintMatchingStrategy { get; set; } // "fuzzy" "exact" "loose"
        public int allowedActivations { get; set; }
        public int allowedDeactivations { get; set; }
        public string? type { get; set; } // "node-locked" "hosted-floating" "on-premise-floating"
        public int allowedFloatingClients { get; set; }
        public int serverSyncGracePeriod { get; set; }
        public int serverSyncInterval { get; set; }
        public int allowedClockOffset { get; set; }
        public int expiringSoonEventOffset { get; set; }
        public int leaseDuration { get; set; }
        public string? leasingStrategy { get; set; } // "per-machine" "per-instance"
        public DateTime? expiresAt { get; set; }
        public bool allowVmActivation { get; set; }
        public bool allowContainerActivation { get; set; }
        public bool userLocked { get; set; }
        public bool requireAuthentication { get; set; }
        public bool disableGeoLocation { get; set; }
        public string? notes { get; set; }
        public string? productId { get; set; }
        public string? productVersionId { get; set; }
        public User user { get; set; }
        public User reseller { get; set; }
        public List<string>? additionalUserIds { get; set; }
        public string? allowedIpRange { get; set; }
        public List<string>? allowedIpRanges { get; set; }
        public List<string>? allowedIpAddresses { get; set; }
        public List<string>? disallowedIpAddresses { get; set; }
        public List<string>? allowedCountries { get; set; }
        public List<string>? disallowedCountries { get; set; }
        public List<Metadata>? metadata { get; set; }
        public List<LicenseMeterAttribute>? meterAttributes { get; set; }
        public List<string>? tags { get; set; }
    }
}
