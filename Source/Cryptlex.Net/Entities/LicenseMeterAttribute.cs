using System;

namespace Cryptlex.Net.Entities
{
    public class LicenseMeterAttribute
    {
        public string? Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Name { get; set; }
        public int AllowedUses { get; set; }
        public int? TotalUses { get; set; }
        public int? GrossUses { get; set; }
        public int Uses { get; set; }
        public bool Floating { get; set; }
        public bool Visible { get; set; }
    }
}