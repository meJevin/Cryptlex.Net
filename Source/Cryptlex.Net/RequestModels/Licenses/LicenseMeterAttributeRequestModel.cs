using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Cryptlex.Net.Licenses
{
    public class LicenseMeterAttributeRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("allowedUses")]
        public int AllowedUses { get; set; }
        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }
        [JsonPropertyName("floating")]
        public bool? Floating { get; set; }

        public LicenseMeterAttributeRequestModel(string name, int allowedUses)
        {
            this.Name = name;
            this.AllowedUses = allowedUses;
        }
    }
}
