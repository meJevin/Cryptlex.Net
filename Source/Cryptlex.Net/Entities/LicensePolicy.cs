using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class LicensePolicy
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? name { get; set; }
        public bool allowVmActivation { get; set; }
        public bool allowContainerActivation { get; set; }
        public bool userLocked { get; set; }
        public bool disableGeoLocation { get; set; }
        public string? allowedIpRange { get; set; }
        public List<string>? allowedIpRanges { get; set; }
        public List<string>? allowedCountries { get; set; }
        public List<string>? disallowedCountries { get; set; }
        public List<string>? allowedIpAddresses { get; set; }
        public List<string>? disallowedIpAddresses { get; set; }
        public int validity { get; set; }
        public string? expirationStrategy { get; set; } // "immediate" "delayed" "rolling"
        public string? fingerprintMatchingStrategy { get; set; } // "fuzzy" "exact" "loose"
        public int allowedActivations { get; set; }
        public int allowedDeactivations { get; set; }
        public string? type { get; set; } // "node-locked" "hosted-floating" "on-premise-floating"
        public string? keyPattern { get; set; }
        public int leaseDuration { get; set; }
        public bool allowClientLeaseDuration { get; set; }
        public string? leasingStrategy { get; set; } // "per-machine" "per-instance"
        public int allowedFloatingClients { get; set; }
        public int serverSyncGracePeriod { get; set; }
        public int serverSyncInterval { get; set; }
        public int allowedClockOffset { get; set; }
        public bool disableClockValidation { get; set; }
        public int expiringSoonEventOffset { get; set; }
        public bool requireAuthentication { get; set; }
        public List<string>? requiredMetadataKeys { get; set; }
        public List<string>? requiredMeterAttributes { get; set; }
    }
}
