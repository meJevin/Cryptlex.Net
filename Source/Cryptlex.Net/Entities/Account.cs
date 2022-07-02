namespace Cryptlex.Net.Entities
{
    public class Account
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Company { get; set; }
        public string? Email { get; set; }
        /// <summary>
        /// "active" "inactive"
        /// </summary>
        public string? Status { get; set; } 
        public string? CustomDomain { get; set; }
        public string? Website { get; set; }
        public string? LogoUrl { get; set; }
        public string? FaviconUrl { get; set; }
        public string? GoogleClientId { get; set; }
        public DateTime TrialExpiresAt { get; set; }
        public Plan Plan { get; set; }
        public string? CompanyId { get; set; }
    }
}