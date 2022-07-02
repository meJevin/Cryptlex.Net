using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Accounts
{
    public class AccountLoginResponse
    {
		[JsonPropertyName("accessToken")]
        public string? AccessToken { get; set; }
    }
}