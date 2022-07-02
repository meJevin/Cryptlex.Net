using System.Text.Json.Serialization;
using Cryptlex.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.PersonalAccessTokens
{
    public class UpdatePersonalAccessTokenData
    {
		[JsonPropertyName("revoked")]
        public bool Revoked { get; set; }

        public UpdatePersonalAccessTokenData(bool revoked)
        {
            this.Revoked = revoked;
        }
    }
}