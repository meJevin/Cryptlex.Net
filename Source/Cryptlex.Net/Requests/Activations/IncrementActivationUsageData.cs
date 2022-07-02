using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class IncrementActivationUsageData
    {
		[JsonPropertyName("increment")]
        public long Increment { get; set; }
		[JsonPropertyName("activationId")]
        public string ActivationId { get; set; }

        public IncrementActivationUsageData(long increment, string activationId)
        {
            this.Increment = increment;
            this.ActivationId = activationId;
        }
    }
}