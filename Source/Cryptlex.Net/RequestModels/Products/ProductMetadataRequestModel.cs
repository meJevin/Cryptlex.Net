using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Products
{
    public class ProductMetadataRequestModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public bool Visible { get; set; }

        public ProductMetadataRequestModel(string key, string value, bool visible)
        {
            this.Key = key;
            this.Value = value;
            this.Visible = visible;
        }
    }
}
