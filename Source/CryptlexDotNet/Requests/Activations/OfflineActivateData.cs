using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Activations
{
    public class OfflineActivateData
    {
        public string offlineRequest { get; set; }
        public int responseValidity { get; set; }
        public string licenseId { get; set; }

        protected OfflineActivateData()
        {

        }

        public OfflineActivateData(string offlineRequest, int responseValidity, string licenseId)
        {
            this.offlineRequest = offlineRequest;
            this.responseValidity = responseValidity;
            this.licenseId = licenseId;
        }
    }
}
