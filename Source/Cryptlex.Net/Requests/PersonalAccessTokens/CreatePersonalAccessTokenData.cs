using System.Text.Json.Serialization;
using Cryptlex.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.PersonalAccessTokens
{
    public class CreatePersonalAccessTokenData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("revoked")]
        public bool? Revoked { get; set; }
		[JsonPropertyName("expiresAt")]
        public DateTime? ExpiresAt { get; set; }
		[JsonPropertyName("scopes")]
        public List<string> Scopes { get; set; }

        public CreatePersonalAccessTokenData(string name, List<string> scopes)
        {
            this.Name = name;
            this.Scopes = scopes;
        }
    }
}