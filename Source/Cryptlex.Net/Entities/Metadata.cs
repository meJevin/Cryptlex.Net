using System;
using System.Collections.Generic;
using System.Linq;

namespace Cryptlex.Net.Entities
{
    public class Metadata
    {
        public string? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
        public bool Visible { get; set; }
    }
}