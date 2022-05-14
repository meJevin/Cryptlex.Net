namespace Cryptlex.Net.TrialPolicies
{
    public class CreateTrialPolicyData
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
        public int trialLength { get; set; }

        public CreateTrialPolicyData(
            string name, string fingerprintMatchingStrategy, bool allowVmActivation, 
            bool allowContainerActivation, bool userLocked, bool disableGeoLocation, 
            int trialLength)
        {
            this.name = name;
            this.fingerprintMatchingStrategy = fingerprintMatchingStrategy;
            this.allowVmActivation = allowVmActivation;
            this.allowContainerActivation = allowContainerActivation;
            this.userLocked = userLocked;
            this.disableGeoLocation = disableGeoLocation;
            this.trialLength = trialLength;
        }
    }
}
