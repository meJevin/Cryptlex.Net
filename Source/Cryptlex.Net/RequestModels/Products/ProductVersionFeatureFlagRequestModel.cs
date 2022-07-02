using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Products
{
    public class ProductVersionFeatureFlagRequestModel
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string? Data { get; set; }

        public ProductVersionFeatureFlagRequestModel(string name, bool enabled)
        {
            this.Name = name;
            this.Enabled = enabled;
        }
    }
}
