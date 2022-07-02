using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class OfflineDeactivateData
    {
		[JsonPropertyName("offlineRequest")]
        public string OfflineRequest { get; set; }
		[JsonPropertyName("licenseId")]
        public string LicenseId { get; set; }

        public OfflineDeactivateData(string offlineRequest, string licenseId)
        {
            this.OfflineRequest = offlineRequest;
            this.LicenseId = licenseId;
        }
    }
}