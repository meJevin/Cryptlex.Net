using System.Text.Json.Serialization;
namespace Cryptlex.Net.TrialActivations
{
    public class ExtendTrialActivationData
    {
		[JsonPropertyName("extensionLength")]
        public int ExtensionLength { get; set; }

        public ExtendTrialActivationData(int extensionLength)
        {
            this.ExtensionLength = extensionLength;
        }
    }
}