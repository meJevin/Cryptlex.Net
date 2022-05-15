namespace Cryptlex.Net.Releases
{
    public class CheckForUpdateReleaseData
    {
        public string platform { get; set; }
        public string productId { get; set; }
        public string? channel { get; set; }
        public string version { get; set; }
        public string key { get; set; }

        public CheckForUpdateReleaseData(
            string platform, string productId, 
            string version, string key)
        {
            this.platform = platform;
            this.productId = productId;
            this.version = version;
            this.key = key;
        }
    }
}
