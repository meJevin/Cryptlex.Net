using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class ActivationMetadataRequestModel
    {
        public string key { get; set; }
        public string value { get; set; }

        protected ActivationMetadataRequestModel()
        {

        }

        public ActivationMetadataRequestModel(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
