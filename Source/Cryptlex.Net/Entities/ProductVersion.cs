using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class ProductVersion
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? name { get; set; }
        public string? displayName { get; set; }
        public string? description { get; set; }
        public string? productId { get; set; }
        public List<FeatureFlag>? featureFlags { get; set; }
    }
}
