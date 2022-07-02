using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class EmailTemplate
    {
        public string? Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? Name { get; set; }
        public string? FromName { get; set; }
        public string? FromEmail { get; set; }
        public string? Cc { get; set; }
        public string? Bcc { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? ReplyTo { get; set; }
        public string? Event { get; set; }
        public bool Enabled { get; set; }
        public bool Custom { get; set; }
        public int Sent { get; set; }
    }
}