namespace Cryptlex.Net.Webhooks
{
    public class CreateWebhookData
    {
        public string name { get; set; }
        public string url { get; set; }
        public string token { get; set; }
        public bool active { get; set; }
        public List<string> events { get; set; }

        public CreateWebhookData(
            string name, string url, string token,
            bool active, List<string> events)
        {
            this.name = name;
            this.url = url;
            this.token = token;
            this.active = active;
            this.events = events;
        }
    }
}
