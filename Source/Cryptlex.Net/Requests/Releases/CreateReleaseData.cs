namespace Cryptlex.Net.Releases
{
    public class CreateReleaseData
    {
        public string name { get; set; }
        public string version { get; set; }
        public string channel { get; set; }
        public string platform { get; set; }
        public bool? @private { get; set; }
        public string? notes { get; set; }
        public string productId { get; set; }
        public DateTime? createdAt { get; set; }

        public CreateReleaseData(
            string name, string version, string channel,
            string platform, string productId)
        {
            this.name = name;
            this.version = version;
            this.channel = channel;
            this.platform = platform;
            this.productId = productId;
        }
    }
}
