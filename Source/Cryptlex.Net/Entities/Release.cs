
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class Release
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
        public string? Channel { get; set; }
        public string? Version { get; set; }
        public string? Platform { get; set; }
        public string? Notes { get; set; }
        public int TotalFiles { get; set; }
        public List<ReleaseFile>? Files { get; set; }
        public bool Published { get; set; }
        public bool @private { get; set; }
        public string? ProductId { get; set; }
        public string? TenantId { get; set; }
    }
}