using System.Text.Json.Serialization;
namespace Cryptlex.Net.TrialActivations
{
    public class CreateTrialActivationData
    {
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
		[JsonPropertyName("metadata")]
        public List<TrialActivationMetadataRequestModel>? Metadata { get; set; }

        public CreateTrialActivationData(
            string os, string fingerprint, string hostname,
            string appVersion, string userHash, string productId)
        {
            this.Os = os;
            this.Fingerprint = fingerprint;
            this.Hostname = hostname;
            this.AppVersion = appVersion;
            this.UserHash = userHash;
            this.ProductId = productId;
        }
    }
}