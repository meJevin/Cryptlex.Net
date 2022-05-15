namespace Cryptlex.Net.Releases
{
    public class GetLatestReleaseData
    {
        public string platform { get; set; }
        public string productId { get; set; }
        public string? channel { get; set; }
        public string key { get; set; }

        public GetLatestReleaseData(
            string platform, string productId, string key)
        {
            this.platform = platform;
            this.productId = productId;
            this.key = key;
        }
    }
}
