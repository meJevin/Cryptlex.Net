using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class TrialActivation
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? os { get; set; } //  "windows" "linux" "macos" "android" "ios"
        public string? osVersion { get; set; }
        public string? hostname { get; set; }
        public Location location { get; set; }
        public string? vmName { get; set; }
        public bool container { get; set; }
        public bool offline { get; set; }
        public string? appVersion { get; set; }
        public string? productId { get; set; }
        public DateTime? expiresAt { get; set; }
        public List<ActivationMetadata>? metadata { get; set; }
    }
}
