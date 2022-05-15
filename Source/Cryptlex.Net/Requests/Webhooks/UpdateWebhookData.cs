namespace Cryptlex.Net.Webhooks
{
    public class UpdateWebhookData
    {
        public string? name { get; set; }
        public string? url { get; set; }
        public string? token { get; set; }
        public bool? active { get; set; }
        public List<string>? events { get; set; }    
    }
}
