using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.RequestModels
{
    public class ProductVersionFeatureFlagRequestModel
    {
        public string name { get; set; }
        public bool enabled { get; set; }
        public string? data { get; set; }

        public ProductVersionFeatureFlagRequestModel(string name, bool enabled)
        {
            this.name = name;
            this.enabled = enabled;
        }
    }
}
