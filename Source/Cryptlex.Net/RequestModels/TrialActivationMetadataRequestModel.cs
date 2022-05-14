using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.RequestModels
{
    public class TrialActivationMetadataRequestModel
    {
        public string key { get; set; }
        public string value { get; set; }

        public TrialActivationMetadataRequestModel(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
