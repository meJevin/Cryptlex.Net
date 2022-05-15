namespace Cryptlex.Net.Entities
{
    public class Account
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? company { get; set; }
        public string? email { get; set; }
        public string? status { get; set; } // "active" "inactive"
        public string? customDomain { get; set; }
        public string? website { get; set; }
        public string? logoUrl { get; set; }
        public string? faviconUrl { get; set; }
        public string? googleClientId { get; set; }
        public DateTime trialExpiresAt { get; set; }
        public Plan plan { get; set; }
        public string? companyId { get; set; }
    }
}