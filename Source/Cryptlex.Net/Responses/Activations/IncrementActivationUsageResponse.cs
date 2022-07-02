using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class IncrementActivationUsageResponse
    {
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("uses")]
        public int Uses { get; set; }
		[JsonPropertyName("licenseAllowedUses")]
        public int LicenseAllowedUses { get; set; }
		[JsonPropertyName("licenseTotalUses")]
        public int LicenseTotalUses { get; set; }
		[JsonPropertyName("licenseGrossUses")]
        public int LicenseGrossUses { get; set; }
    }
}