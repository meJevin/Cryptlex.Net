using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Users
{
    public class UserMetadataRequestModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Visible { get; set; }

        public UserMetadataRequestModel(string key, string value, bool visible)
        {
            this.Key = key;
            this.Value = value;
            this.Visible = visible;
        }
    }
}
