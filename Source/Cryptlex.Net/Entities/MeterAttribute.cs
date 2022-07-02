using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class MeterAttribute
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("allowedUses")]
        public int AllowedUses { get; set; }
		[JsonPropertyName("visible")]
        public bool Visible { get; set; }
		[JsonPropertyName("floating")]
        public bool Floating { get; set; }
    }
}