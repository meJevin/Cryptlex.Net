namespace Cryptlex.Net.Releases
{
    public class UpdateReleaseData
    {
        public string? name { get; set; }
        public string? version { get; set; }
        public string? channel { get; set; }
        public string? platform { get; set; }
        public bool? @private { get; set; }
        public string? notes { get; set; }
        public string? productId { get; set; }
        public DateTime? createdAt { get; set; }
    }
}
