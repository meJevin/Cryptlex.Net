using System;
using System.Collections.Generic;

namespace Cryptlex.Net.Entities
{
    public class User
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Company { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool GoogleSsoEnabled { get; set; }
        public bool AllowCustomerPortalAccess { get; set; }
        public string? Role { get; set; }
        public List<string>? Roles { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public List<Metadata>? Metadata { get; set; }
        public List<string>? Tags { get; set; }
    }
}