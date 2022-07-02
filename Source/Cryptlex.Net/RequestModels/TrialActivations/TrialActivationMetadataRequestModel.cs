using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.TrialActivations
{
    public class TrialActivationMetadataRequestModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public TrialActivationMetadataRequestModel(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
