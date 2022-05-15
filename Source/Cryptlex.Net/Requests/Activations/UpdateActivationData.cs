using Cryptlex.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class UpdateActivationData
    {
        public string os { get; set; }
        public string? osVersion { get; set; }
        public string fingerprint { get; set; }
        public string? vmName { get; set; }
        public bool? container { get; set; }
        public string hostname { get; set; }
        public string appVersion { get; set; }
        public string userHash { get; set; }
        public string productId { get; set; }
        public string key { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public int? leaseDuration { get; set; }
        public List<ActivationMetadataRequestModel>? metadata { get; set; }
        public List<ActivationMeterAttributeRequestModel>? meterAttributes { get; set; }

        public UpdateActivationData(
            string os, string fingerprint, string hostname, 
            string appVersion, string userHash, string productId, 
            string key)
        {
            this.os = os;
            this.fingerprint = fingerprint;
            this.hostname = hostname;
            this.appVersion = appVersion;
            this.userHash = userHash;
            this.productId = productId;
            this.key = key;
        }
    }
}
