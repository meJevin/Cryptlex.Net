using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class UpdateActivationResponse
    {
		[JsonPropertyName("activationToken")]
        public string? ActivationToken { get; set; }
    }
}