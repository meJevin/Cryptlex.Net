namespace Cryptlex.Net.TrialPolicies
{
    public class UpdateTrialPolicyData
    {
        public string? name { get; set; }
        public string? fingerprintMatchingStrategy { get; set; }
        public bool? allowVmActivation { get; set; }
        public bool? allowContainerActivation { get; set; }
        public bool? userLocked { get; set; }
        public bool? disableGeoLocation { get; set; }
        public string? allowedIpRange { get; set; }
        public List<string>? allowedIpRanges { get; set; }
        public List<string>? allowedCountries { get; set; }
        public List<string>? disallowedCountries { get; set; }
        public List<string>? allowedIpAddresses { get; set; }
        public List<string>? disallowedIpAddresses { get; set; }
        public int? trialLength { get; set; }                                        
    }
}
