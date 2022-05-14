
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class Release
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? name { get; set; }
        public string? channel { get; set; }
        public string? version { get; set; }
        public string? platform { get; set; }
        public string? notes { get; set; }
        public int totalFiles { get; set; }
        public List<ReleaseFile>? files { get; set; }
        public bool published { get; set; }
        public bool @private { get; set; }
        public string? productId { get; set; }
        public string? tenantId { get; set; }
    }
}
