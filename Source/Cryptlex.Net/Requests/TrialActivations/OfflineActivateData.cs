namespace Cryptlex.Net.TrialActivations
{
    public class OfflineActivateData
    {
        public string offlineRequest { get; set; }
        public int responseValidity { get; set; }
        public string productId { get; set; }

        public OfflineActivateData(string offlineRequest, int responseValidity, string productId)
        {
            this.offlineRequest = offlineRequest;
            this.responseValidity = responseValidity;
            this.productId = productId;
        }
    }
}
