using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Licenses
{
    public class LicenseMetadataRequestModel
    {
        public string key { get; set; }
        public string value { get; set; }
        public bool visible { get; set; }

        protected LicenseMetadataRequestModel()
        {

        }

        public LicenseMetadataRequestModel(string key, string value, bool visible)
        {
            this.key = key;
            this.value = value;
            this.visible = visible;
        }
    }
}
