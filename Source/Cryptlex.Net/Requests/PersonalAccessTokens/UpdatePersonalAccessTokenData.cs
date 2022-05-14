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
        public bool revoked { get; set; }

        public UpdatePersonalAccessTokenData(bool revoked)
        {
            this.revoked = revoked;
        }
    }
}
