using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cryptlex.Net
{
    public interface IListRequest
    {
        [JsonPropertyName("page")]
        int? Page { get; set; }
        [JsonPropertyName("limit")]
        int? Limit { get; set; }
        [JsonPropertyName("sort")]
        string? Sort { get; set; }
    }

    public class DefaultListRequest : IListRequest
    {
        [JsonPropertyName("page")]
        public int? Page { get; set; } = 1;
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }
        [JsonPropertyName("sort")]
        public string? Sort { get; set; }
    }
}
