using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class ReleaseFile
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int Size { get; set; }
        public int Downloads { get; set; }
        public string? Extension { get; set; }
        public string? Checksum { get; set; }
        public bool Secured { get; set; }
        public string? ReleaseId { get; set; }
    }
}