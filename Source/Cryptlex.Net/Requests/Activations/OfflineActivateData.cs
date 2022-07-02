using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class OfflineActivateData
    {
		[JsonPropertyName("offlineRequest")]
        public string OfflineRequest { get; set; }
		[JsonPropertyName("responseValidity")]
        public int ResponseValidity { get; set; }
		[JsonPropertyName("licenseId")]
        public string LicenseId { get; set; }

        public OfflineActivateData(string offlineRequest, int responseValidity, string licenseId)
        {
            this.OfflineRequest = offlineRequest;
            this.ResponseValidity = responseValidity;
            this.LicenseId = licenseId;
        }
    }
}