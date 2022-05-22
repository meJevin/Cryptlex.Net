using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class EmailTemplate
    {
        public string? id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string? name { get; set; }
        public string? fromName { get; set; }
        public string? fromEmail { get; set; }
        public string? cc { get; set; }
        public string? bcc { get; set; }
        public string? subject { get; set; }
        public string? body { get; set; }
        public string? replyTo { get; set; }
        public string? @event { get; set; }
        public bool enabled { get; set; }
        public bool custom { get; set; }
        public int sent { get; set; }
    }
}
