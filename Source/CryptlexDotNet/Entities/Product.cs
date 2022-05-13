using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Entities
{
    public class Product
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? name { get; set; }
        public string? displayName { get; set; }
        public string? description { get; set; }
        public string? publicKey { get; set; }
        public int totalLicenses { get; set; }
        public int totalTrialActivations { get; set; }
        public int totalReleases { get; set; }
        public int totalProductVersions { get; set; }
        public int totalFeatureFlags { get; set; }
        public List<string>? emailTemplates { get; set; }
        public LicensePolicy licensePolicy { get; set; }
        public TrialPolicy trialPolicy { get; set; }
        public List<Metadata>? metadata { get; set; }
    }
}
