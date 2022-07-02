using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class EmailTemplate
    {
		[JsonPropertyName("id")]
        public string? Id { get; set; }
		[JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
		[JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
		[JsonPropertyName("name")]
        public string? Name { get; set; }
		[JsonPropertyName("fromName")]
        public string? FromName { get; set; }
		[JsonPropertyName("fromEmail")]
        public string? FromEmail { get; set; }
		[JsonPropertyName("cc")]
        public string? Cc { get; set; }
		[JsonPropertyName("bcc")]
        public string? Bcc { get; set; }
		[JsonPropertyName("subject")]
        public string? Subject { get; set; }
		[JsonPropertyName("body")]
        public string? Body { get; set; }
		[JsonPropertyName("replyTo")]
        public string? ReplyTo { get; set; }
		[JsonPropertyName("event")]
        public string? Event { get; set; }
		[JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
		[JsonPropertyName("custom")]
        public bool Custom { get; set; }
		[JsonPropertyName("sent")]
        public int Sent { get; set; }
    }
}