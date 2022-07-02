using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class TrialActivation
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// "windows" "linux" "macOs" "android" "iOs"
        /// </summary>
        public string? Os { get; set; } 
        public string? OsVersion { get; set; }
        public string? Hostname { get; set; }
        public Location Location { get; set; }
        public string? VmName { get; set; }
        public bool Container { get; set; }
        public bool Offline { get; set; }
        public string? AppVersion { get; set; }
        public string? ProductId { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public List<ActivationMetadata>? Metadata { get; set; }
    }
}