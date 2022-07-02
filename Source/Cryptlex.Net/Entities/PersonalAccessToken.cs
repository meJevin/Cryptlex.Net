using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class PersonalAccessToken
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public bool Revoked { get; set; }
        public List<string>? Scopes { get; set; }
    }
}