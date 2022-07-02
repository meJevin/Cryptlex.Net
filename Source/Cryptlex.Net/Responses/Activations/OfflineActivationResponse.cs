using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class OfflineActivationResponse
    {
		[JsonPropertyName("offlineResponse")]
        public string? OfflineResponse { get; set; }
    }
}