using System;

namespace CryptlexDotNet.Entities
{
    public class LicenseMeterAttribute
    {
        public string? id { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? name { get; set; }
        public int allowedUses { get; set; }
        public int? totalUses { get; set; }
        public int? grossUses { get; set; }
        public int uses { get; set; }
        public bool floating { get; set; }
        public bool visible { get; set; }
    }
}
