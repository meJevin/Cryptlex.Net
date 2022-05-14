using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Users
{
    public class UserMetadataRequestModel
    {
        public string key { get; set; }
        public string value { get; set; }
        public bool visible { get; set; }

        public UserMetadataRequestModel(string key, string value, bool visible)
        {
            this.key = key;
            this.value = value;
            this.visible = visible;
        }
    }
}
