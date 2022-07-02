using Cryptlex.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class CreateActivationResponse
    {
        [JsonPropertyName("activationToken")]
        public string? ActivationToken { get; set; }
    }
}
