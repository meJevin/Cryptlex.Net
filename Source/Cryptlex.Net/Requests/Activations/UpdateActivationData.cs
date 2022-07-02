using System.Text.Json.Serialization;
using Cryptlex.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class UpdateActivationData
    {
        /// <summary>
        ///  Name of the operating system
        ///  Enum: "windows" "linux" "macos" "android" "ios" 
        /// </summary>
        [JsonPropertyName("os")]
        public string Os { get; set; }
		[JsonPropertyName("osVersion")]
        public string? OsVersion { get; set; }
		[JsonPropertyName("fingerprint")]
        public string Fingerprint { get; set; }
		[JsonPropertyName("vmName")]
        public string? VmName { get; set; }
		[JsonPropertyName("container")]
        public bool? Container { get; set; }
		[JsonPropertyName("hostname")]
        public string Hostname { get; set; }
		[JsonPropertyName("appVersion")]
        public string AppVersion { get; set; }
		[JsonPropertyName("userHash")]
        public string UserHash { get; set; }
		[JsonPropertyName("productId")]
        public string ProductId { get; set; }
        [JsonPropertyName("accountId")]
        public string? AccountId { get; set; }
        [JsonPropertyName("releaseVersion")]
        public string? ReleaseVersion { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
		[JsonPropertyName("email")]
        public string? Email { get; set; }
		[JsonPropertyName("password")]
        public string? Password { get; set; }
		[JsonPropertyName("leaseDuration")]
        public int? LeaseDuration { get; set; }
		[JsonPropertyName("metadata")]
        public List<ActivationMetadataRequestModel>? Metadata { get; set; }
		[JsonPropertyName("meterAttributes")]
        public List<ActivationMeterAttributeRequestModel>? MeterAttributes { get; set; }

        public UpdateActivationData(
            string os, string fingerprint, string hostname, 
            string appVersion, string userHash, string productId, 
            string key)
        {
            this.Os = os;
            this.Fingerprint = fingerprint;
            this.Hostname = hostname;
            this.AppVersion = appVersion;
            this.UserHash = userHash;
            this.ProductId = productId;
            this.Key = key;
        }
    }
}