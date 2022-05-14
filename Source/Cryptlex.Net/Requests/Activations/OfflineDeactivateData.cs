using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class OfflineDeactivateData
    {
        public string offlineRequest { get; set; }
        public string licenseId { get; set; }

        public OfflineDeactivateData(string offlineRequest, string licenseId)
        {
            this.offlineRequest = offlineRequest;
            this.licenseId = licenseId;
        }
    }
}
