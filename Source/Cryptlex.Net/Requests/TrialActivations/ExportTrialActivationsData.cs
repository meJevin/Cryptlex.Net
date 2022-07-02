using System.Text.Json.Serialization;
namespace Cryptlex.Net.TrialActivations
{
    public class ExportTrialActivationsData
    {
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
    }
}