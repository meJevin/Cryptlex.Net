namespace Cryptlex.Net.EmailTemplates
{
    public class UpdateEmailTemplateData
    {
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
    }
}
