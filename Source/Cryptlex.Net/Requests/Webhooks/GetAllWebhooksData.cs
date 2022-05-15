namespace Cryptlex.Net.Webhooks
{
    public class GetAllWebhooksData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? query { get; set; }
    }
}
