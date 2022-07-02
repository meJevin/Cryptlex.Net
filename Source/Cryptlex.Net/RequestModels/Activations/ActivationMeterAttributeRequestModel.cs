using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Cryptlex.Net.Activations
{
    public class ActivationMeterAttributeRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("usesIncrement")]
        public int UsesIncrement { get; set; }

        protected ActivationMeterAttributeRequestModel()
        {

        }

        public ActivationMeterAttributeRequestModel(string name, int usesIncrement)
        {
            this.Name = name;
            this.UsesIncrement = usesIncrement;
        }
    }
}
