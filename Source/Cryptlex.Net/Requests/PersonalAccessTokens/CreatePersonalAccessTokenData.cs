using Cryptlex.Net.Entities;
using Cryptlex.Net.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.PersonalAccessTokens
{
    public class CreatePersonalAccessTokenData
    {
        public string name { get; set; }
        public bool? revoked { get; set; }
        public DateTime? expiresAt { get; set; }
        public List<string> scopes { get; set; }

        public CreatePersonalAccessTokenData(string name, List<string> scopes)
        {
            this.name = name;
            this.scopes = scopes;
        }
    }
}
