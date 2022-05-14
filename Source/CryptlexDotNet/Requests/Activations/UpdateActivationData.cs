using CryptlexDotNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Activations
{
    public class UpdateActivationData
    {
        public string key { get; set; }
        public bool revoked { get; set; }
        public bool suspended { get; set; }
        public string fingerprintMatchingStrategy { get; set; }
        public int allowedActivations { get; set; }
        public int allowedDeactivations { get; set; }
        public int leaseDuration { get; set; }
        public bool allowClientLeaseDuration { get; set; }
        public int allowedFloatingClients { get; set; }
        public int serverSyncGracePeriod { get; set; }
        public int serverSyncInterval { get; set; }
        public int allowedClockOffset { get; set; }
        public bool disableClockValidation { get; set; }
        public int expiringSoonEventOffset { get; set; }
        public bool allowVmActivation { get; set; }
        public bool allowContainerActivation { get; set; }
        public bool requireAuthentication { get; set; }
        public bool disableGeoLocation { get; set; }
        public string notes { get; set; }
        public string allowedIpRange { get; set; }
        public List<string> allowedIpRanges { get; set; }
        public List<string> allowedCountries { get; set; }
        public List<string> disallowedCountries { get; set; }
        public List<string> allowedIpAddresses { get; set; }
        public List<string> disallowedIpAddresses { get; set; }
        public string userId { get; set; }
        public string resellerId { get; set; }
        public List<string> additionalUserIds { get; set; }
        public string productVersionId { get; set; }
        public List<string> tags { get; set; }
        public List<Metadata> metadata { get; set; }
        public List<MeterAttribute> meterAttributes { get; set; }
    }
}
