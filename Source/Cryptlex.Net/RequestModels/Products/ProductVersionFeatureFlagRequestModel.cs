using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Cryptlex.Net.Products
{
    public class ProductVersionFeatureFlagRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
        [JsonPropertyName("data")]
        public string? Data { get; set; }

        public ProductVersionFeatureFlagRequestModel(string name, bool enabled)
        {
            this.Name = name;
            this.Enabled = enabled;
        }
    }
}
