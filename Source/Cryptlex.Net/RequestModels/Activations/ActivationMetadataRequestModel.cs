using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class ActivationMetadataRequestModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        protected ActivationMetadataRequestModel()
        {

        }

        public ActivationMetadataRequestModel(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
