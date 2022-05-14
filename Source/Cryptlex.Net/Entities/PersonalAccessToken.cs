using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class PersonalAccessToken
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? name { get; set; }
        public DateTime? expiresAt { get; set; }
        public bool revoked { get; set; }
        public List<string>? scopes { get; set; }
    }
}
