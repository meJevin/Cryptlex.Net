using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Cryptlex.Net.Users
{
    public class UserMetadataRequestModel
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("visible")]
        public bool Visible { get; set; }

        public UserMetadataRequestModel(string key, string value, bool visible)
        {
            this.Key = key;
            this.Value = value;
            this.Visible = visible;
        }
    }
}
