using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class LicensePolicy
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
        public bool AllowVmActivation { get; set; }
        public bool AllowContainerActivation { get; set; }
        public bool UserLocked { get; set; }
        public bool DisableGeoLocation { get; set; }
        public string? AllowedIpRange { get; set; }
        public List<string>? AllowedIpRanges { get; set; }
        public List<string>? AllowedCountries { get; set; }
        public List<string>? DisallowedCountries { get; set; }
        public List<string>? AllowedIpAddresses { get; set; }
        public List<string>? DisallowedIpAddresses { get; set; }
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
        public string? KeyPattern { get; set; }
        public int LeaseDuration { get; set; }
        public bool AllowClientLeaseDuration { get; set; }
        /// <summary>
        /// "per-machine" "per-instance"
        /// </summary>
        public string? LeasingStrategy { get; set; }
        public int AllowedFloatingClients { get; set; }
        public int ServerSyncGracePeriod { get; set; }
        public int ServerSyncInterval { get; set; }
        public int AllowedClockOffset { get; set; }
        public bool DisableClockValidation { get; set; }
        public int ExpiringSoonEventOffset { get; set; }
        public bool RequireAuthentication { get; set; }
        public List<string>? RequiredMetadataKeys { get; set; }
        public List<string>? RequiredMeterAttributes { get; set; }
    }
}