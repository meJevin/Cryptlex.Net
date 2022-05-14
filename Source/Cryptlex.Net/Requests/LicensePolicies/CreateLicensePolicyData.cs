namespace Cryptlex.Net.LicensePolicies
{
    public class CreateLicensePolicyData
    {
        public string name { get; set; }
        public string fingerprintMatchingStrategy { get; set; }
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
        public string expirationStrategy { get; set; } // "immediate" "delayed" "rolling"
        public int allowedActivations { get; set; }
        public int allowedDeactivations { get; set; }
        public string type { get; set; }
        public string? keyPattern { get; set; }
        public int? leaseDuration { get; set; }
        public bool allowClientLeaseDuration { get; set; }
        public string? leasingStrategy { get; set; } // "per-machine" "per-instance"
        public int? allowedFloatingClients { get; set; }
        public int serverSyncGracePeriod { get; set; }
        public int serverSyncInterval { get; set; }
        public int allowedClockOffset { get; set; }
        public bool disableClockValidation { get; set; }
        public int expiringSoonEventOffset { get; set; }
        public bool requireAuthentication { get; set; }
        public List<string>? requiredMetadataKeys { get; set; }
        public List<string>? requiredMeterAttributes { get; set; }

        public CreateLicensePolicyData(
            string name, string fingerprintMatchingStrategy, bool allowVmActivation,
            bool allowContainerActivation, bool userLocked, bool disableGeoLocation,
            int validity, string expirationStrategy, int allowedActivations,
            int allowedDeactivations, string type, bool allowClientLeaseDuration,
            int serverSyncGracePeriod, int serverSyncInterval, int allowedClockOffset,
            bool disableClockValidation, int expiringSoonEventOffset, bool requireAuthentication)
        {
            this.name = name;
            this.fingerprintMatchingStrategy = fingerprintMatchingStrategy;
            this.allowVmActivation = allowVmActivation;
            this.allowContainerActivation = allowContainerActivation;
            this.userLocked = userLocked;
            this.disableGeoLocation = disableGeoLocation;
            this.validity = validity;
            this.expirationStrategy = expirationStrategy;
            this.allowedActivations = allowedActivations;
            this.allowedDeactivations = allowedDeactivations;
            this.type = type;
            this.allowClientLeaseDuration = allowClientLeaseDuration;
            this.serverSyncGracePeriod = serverSyncGracePeriod;
            this.serverSyncInterval = serverSyncInterval;
            this.allowedClockOffset = allowedClockOffset;
            this.disableClockValidation = disableClockValidation;
            this.expiringSoonEventOffset = expiringSoonEventOffset;
            this.requireAuthentication = requireAuthentication;
        }
    }
}
