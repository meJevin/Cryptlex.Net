using System;
using System.Collections.Generic;

namespace Cryptlex.Net.Entities
{
    public class User
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? name { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? company { get; set; }
        public bool twoFactorEnabled { get; set; }
        public bool googleSsoEnabled { get; set; }
        public bool allowCustomerPortalAccess { get; set; }
        public string? role { get; set; }
        public List<string>? roles { get; set; }
        public DateTime? lastLoginAt { get; set; }
        public DateTime? lastSeenAt { get; set; }
        public List<Metadata>? metadata { get; set; }
        public List<string>? tags { get; set; }
    }
}
