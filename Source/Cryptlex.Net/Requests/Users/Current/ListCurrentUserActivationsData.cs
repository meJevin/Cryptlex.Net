using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Users.Current
{
    public class ListCurrentUserActivationsData : IListRequest
    {
		[JsonPropertyName("page")]
        public int? Page { get; set; }
		[JsonPropertyName("limit")]
        public int? Limit { get; set; }
		[JsonPropertyName("sort")]
        public string? Sort { get; set; }
		[JsonPropertyName("licenseId")]
        public string? LicenseId { get; set; }
		[JsonPropertyName("query")]
        public string? Query { get; set; }
    }
}