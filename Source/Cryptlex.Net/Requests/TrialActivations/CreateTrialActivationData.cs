namespace Cryptlex.Net.TrialActivations
{
    public class CreateTrialActivationData
    {
        public string os { get; set; }
        public string? osVersion { get; set; }
        public string fingerprint { get; set; }
        public string? vmName { get; set; }
        public bool? container { get; set; }
        public string hostname { get; set; }
        public string appVersion { get; set; }
        public string userHash { get; set; }
        public string productId { get; set; }
        public List<TrialActivationMetadataRequestModel>? metadata { get; set; }

        public CreateTrialActivationData(
            string os, string fingerprint, string hostname,
            string appVersion, string userHash, string productId)
        {
            this.os = os;
            this.fingerprint = fingerprint;
            this.hostname = hostname;
            this.appVersion = appVersion;
            this.userHash = userHash;
            this.productId = productId;
        }
    }
}
