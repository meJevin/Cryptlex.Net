namespace Cryptlex.Net.Entities
{
    public class Plan
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? displayName { get; set; }
        public string? interval { get; set; }
        public int allowedUsers { get; set; }
        public int allowedAdmins { get; set; }
        public int allowedProducts { get; set; }
        public int allowedMeterAttributes { get; set; }
        public int allowedFeatureFlags { get; set; }
        public int allowedActivations { get; set; }
        public int allowedTrialActivations { get; set; }
        public int allowedReleases { get; set; }
        public int allowedProductSpace { get; set; }
        public int allowedSendingDomains { get; set; }
        public string? amount { get; set; }
        public bool allowCustomerPortalAccess { get; set; }
        public bool allowOfflineActivations { get; set; }
        public bool allowHostedFloatingLicenses { get; set; }
        public bool allowOnPremiseFloatingLicenses { get; set; }
        public bool allowCustomDomain { get; set; }
        public bool allowSso { get; set; }
        public bool allowCustomRoles { get; set; }
        public bool allowEventLogs { get; set; }
        public bool allowCustomEmailTemplates { get; set; }
        public bool deprecated { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
