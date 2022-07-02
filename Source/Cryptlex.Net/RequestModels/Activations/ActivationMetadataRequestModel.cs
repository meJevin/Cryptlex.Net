using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Cryptlex.Net.Activations
{
    public class ActivationMetadataRequestModel
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }

        protected ActivationMetadataRequestModel()
        {

        }

        public ActivationMetadataRequestModel(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
