using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class Product
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
		[JsonPropertyName("description")]
        public string? Description { get; set; }
		[JsonPropertyName("publicKey")]
        public string? PublicKey { get; set; }
		[JsonPropertyName("totalLicenses")]
        public int TotalLicenses { get; set; }
		[JsonPropertyName("totalTrialActivations")]
        public int TotalTrialActivations { get; set; }
		[JsonPropertyName("totalReleases")]
        public int TotalReleases { get; set; }
		[JsonPropertyName("totalProductVersions")]
        public int TotalProductVersions { get; set; }
		[JsonPropertyName("totalFeatureFlags")]
        public int TotalFeatureFlags { get; set; }
		[JsonPropertyName("emailTemplates")]
        public List<string>? EmailTemplates { get; set; }
		[JsonPropertyName("licensePolicy")]
        public LicensePolicy LicensePolicy { get; set; }
		[JsonPropertyName("trialPolicy")]
        public TrialPolicy TrialPolicy { get; set; }
		[JsonPropertyName("metadata")]
        public List<Metadata>? Metadata { get; set; }
    }
}