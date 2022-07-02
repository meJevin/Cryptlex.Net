using System;
using System.Collections.Generic;

namespace Cryptlex.Net.Entities
{
    public class Activation
    {
        public string? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
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
        public string? LicenseId { get; set; }
        public DateTime? LastSyncedAt { get; set; }
        public DateTime? LeaseExpiresAt { get; set; }
        public List<ActivationMeterAttribute>? MeterAttributes { get; set; }
    }
}