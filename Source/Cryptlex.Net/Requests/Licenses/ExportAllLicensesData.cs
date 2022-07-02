using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Licenses
{
    public class ExportAllLicensesData
    {
		[JsonPropertyName("productId")]
        public string? ProductId { get; set; }
		[JsonPropertyName("userId")]
        public string? UserId { get; set; }
		[JsonPropertyName("email")]
        public string? Email { get; set; }
		[JsonPropertyName("query")]
        public string? Query { get; set; }
    }
}