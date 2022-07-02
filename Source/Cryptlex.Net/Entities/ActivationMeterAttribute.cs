using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class ActivationMeterAttribute
    {
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("uses")]
        public int Uses { get; set; }
    }
}