using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class Product
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? PublicKey { get; set; }
        public int TotalLicenses { get; set; }
        public int TotalTrialActivations { get; set; }
        public int TotalReleases { get; set; }
        public int TotalProductVersions { get; set; }
        public int TotalFeatureFlags { get; set; }
        public List<string>? EmailTemplates { get; set; }
        public LicensePolicy LicensePolicy { get; set; }
        public TrialPolicy TrialPolicy { get; set; }
        public List<Metadata>? Metadata { get; set; }
    }
}