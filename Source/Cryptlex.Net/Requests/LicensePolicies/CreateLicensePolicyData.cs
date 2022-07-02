using System.Text.Json.Serialization;
namespace Cryptlex.Net.LicensePolicies
{
    public class CreateLicensePolicyData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("fingerprintMatchingStrategy")]
        public string FingerprintMatchingStrategy { get; set; }
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
		[JsonPropertyName("expirationStrategy")]
        public string ExpirationStrategy { get; set; } // "immediate" "delayed" "rolling"
		[JsonPropertyName("allowedActivations")]
        public int AllowedActivations { get; set; }
		[JsonPropertyName("allowedDeactivations")]
        public int AllowedDeactivations { get; set; }
		[JsonPropertyName("type")]
        public string Type { get; set; }
		[JsonPropertyName("keyPattern")]
        public string? KeyPattern { get; set; }
		[JsonPropertyName("leaseDuration")]
        public int? LeaseDuration { get; set; }
		[JsonPropertyName("allowClientLeaseDuration")]
        public bool AllowClientLeaseDuration { get; set; }
		[JsonPropertyName("leasingStrategy")]
        public string? LeasingStrategy { get; set; } // "per-machine" "per-instance"
		[JsonPropertyName("allowedFloatingClients")]
        public int? AllowedFloatingClients { get; set; }
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

        public CreateLicensePolicyData(
            string name, string fingerprintMatchingStrategy, bool allowVmActivation,
            bool allowContainerActivation, bool userLocked, bool disableGeoLocation,
            int validity, string expirationStrategy, int allowedActivations,
            int allowedDeactivations, string type, bool allowClientLeaseDuration,
            int serverSyncGracePeriod, int serverSyncInterval, int allowedClockOffset,
            bool disableClockValidation, int expiringSoonEventOffset, bool requireAuthentication)
        {
            this.Name = name;
            this.FingerprintMatchingStrategy = fingerprintMatchingStrategy;
            this.AllowVmActivation = allowVmActivation;
            this.AllowContainerActivation = allowContainerActivation;
            this.UserLocked = userLocked;
            this.DisableGeoLocation = disableGeoLocation;
            this.Validity = validity;
            this.ExpirationStrategy = expirationStrategy;
            this.AllowedActivations = allowedActivations;
            this.AllowedDeactivations = allowedDeactivations;
            this.Type = type;
            this.AllowClientLeaseDuration = allowClientLeaseDuration;
            this.ServerSyncGracePeriod = serverSyncGracePeriod;
            this.ServerSyncInterval = serverSyncInterval;
            this.AllowedClockOffset = allowedClockOffset;
            this.DisableClockValidation = disableClockValidation;
            this.ExpiringSoonEventOffset = expiringSoonEventOffset;
            this.RequireAuthentication = requireAuthentication;
        }
    }
}