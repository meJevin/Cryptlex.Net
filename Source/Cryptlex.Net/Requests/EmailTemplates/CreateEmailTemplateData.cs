using System.Text.Json.Serialization;
namespace Cryptlex.Net.EmailTemplates
{
    public class CreateEmailTemplateData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("fromName")]
        public string FromName { get; set; }
		[JsonPropertyName("fromEmail")]
        public string FromEmail { get; set; }
		[JsonPropertyName("cc")]
        public string? Cc { get; set; }
		[JsonPropertyName("bcc")]
        public string? Bcc { get; set; }
		[JsonPropertyName("subject")]
        public string Subject { get; set; }
		[JsonPropertyName("body")]
        public string Body { get; set; }
		[JsonPropertyName("replyTo")]
        public string? ReplyTo { get; set; }
		[JsonPropertyName("@event")]
        public string @event { get; set; }
		[JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
		[JsonPropertyName("custom")]
        public bool Custom { get; set; }

        public CreateEmailTemplateData(
            string name, string fromName, string fromEmail, 
            string subject, string body, string @event, 
            bool enabled, bool custom)
        {
            this.Name = name;
            this.FromName = fromName;
            this.FromEmail = fromEmail;
            this.Subject = subject;
            this.Body = body;
            this.@event = @event;
            this.Enabled = enabled;
            this.Custom = custom;
        }
    }
}