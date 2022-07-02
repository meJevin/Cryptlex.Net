using System.Text.Json.Serialization;
namespace Cryptlex.Net.TrialActivations
{
    public class OfflineActivateResponse
    {
		[JsonPropertyName("offlineResponse")]
        public string? OfflineResponse { get; set; }
    }
}