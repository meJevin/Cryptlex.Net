﻿namespace Cryptlex.Net.Webhooks
{
    public class ListWebhooksData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? query { get; set; }
    }
}