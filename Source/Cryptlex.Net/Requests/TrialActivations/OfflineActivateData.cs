using System.Text.Json.Serialization;
namespace Cryptlex.Net.TrialActivations
{
    public class OfflineActivateData
    {
		[JsonPropertyName("offlineRequest")]
        public string OfflineRequest { get; set; }
		[JsonPropertyName("responseValidity")]
        public int ResponseValidity { get; set; }
		[JsonPropertyName("productId")]
        public string ProductId { get; set; }

        public OfflineActivateData(string offlineRequest, int responseValidity, string productId)
        {
            this.OfflineRequest = offlineRequest;
            this.ResponseValidity = responseValidity;
            this.ProductId = productId;
        }
    }
}