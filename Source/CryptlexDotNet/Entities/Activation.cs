using System;
using System.Collections.Generic;

namespace CryptlexDotNet.Entities
{
    public class Activation
    {
        public string? id { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? os { get; set; } // "windows" "linux" "macos" "android" "ios"
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
        public string? licenseId { get; set; }
        public DateTime? lastSyncedAt { get; set; }
        public DateTime? leaseExpiresAt { get; set; }
        public List<ActivationMeterAttribute>? meterAttributes { get; set; }
    }
}
