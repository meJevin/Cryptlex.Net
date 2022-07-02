using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class TrialPolicy
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
        public bool AllowVmActivation { get; set; }
        public bool AllowContainerActivation { get; set; }
        public bool UserLocked { get; set; }
        public bool DisableGeoLocation { get; set; }
        public string? AllowedIpRange { get; set; }
        public List<string>? AllowedIpRanges { get; set; }
        public List<string>? AllowedCountries { get; set; }
        public List<string>? DisallowedCountries { get; set; }
        public List<string>? AllowedIpAddresses { get; set; }
        public List<string>? DisallowedIpAddresses { get; set; }
        public int TrialLength { get; set; }
        /// <summary>
        /// "fuzzy" "exact" "loose"
        /// </summary>
        public string? FingerprintMatchingStrategy { get; set; }
    }
}