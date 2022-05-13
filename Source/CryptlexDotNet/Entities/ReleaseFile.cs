using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Entities
{
    public class ReleaseFile
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? name { get; set; }
        public string? url { get; set; }
        public int size { get; set; }
        public int downloads { get; set; }
        public string? extension { get; set; }
        public string? checksum { get; set; }
        public bool secured { get; set; }
        public string? releaseId { get; set; }
    }
}
