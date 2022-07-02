using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class Error
    {
		[JsonPropertyName("message")]
        public string Message { get; set; }
		[JsonPropertyName("code")]
        public string Code { get; set; }
    }
}