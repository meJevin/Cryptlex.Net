namespace Cryptlex.Net.Entities
{
    public class Plan
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Interval { get; set; }
        public int AllowedUsers { get; set; }
        public int AllowedAdmins { get; set; }
        public int AllowedProducts { get; set; }
        public int AllowedMeterAttributes { get; set; }
        public int AllowedFeatureFlags { get; set; }
        public int AllowedActivations { get; set; }
        public int AllowedTrialActivations { get; set; }
        public int AllowedReleases { get; set; }
        public int AllowedProductSpace { get; set; }
        public int AllowedSendingDomains { get; set; }
        public string? Amount { get; set; }
        public bool AllowCustomerPortalAccess { get; set; }
        public bool AllowOfflineActivations { get; set; }
        public bool AllowHostedFloatingLicenses { get; set; }
        public bool AllowOnPremiseFloatingLicenses { get; set; }
        public bool AllowCustomDomain { get; set; }
        public bool AllowSso { get; set; }
        public bool AllowCustomRoles { get; set; }
        public bool AllowEventLogs { get; set; }
        public bool AllowCustomEmailTemplates { get; set; }
        public bool Deprecated { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}