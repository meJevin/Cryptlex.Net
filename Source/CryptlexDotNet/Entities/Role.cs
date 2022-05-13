using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Entities
{
    public class Role
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public List<string>? claims { get; set; }
    }
}
