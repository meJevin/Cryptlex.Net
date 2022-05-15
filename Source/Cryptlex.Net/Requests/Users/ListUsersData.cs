namespace Cryptlex.Net.Users
{
    public class ListUsersData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? role { get; set; }
        public string? userType { get; set; }
        public string? email { get; set; }
        public string? company{ get; set; }
        public string? tag { get; set; }
        public List<string>? tags { get; set; }
        public string? metadataKey { get; set; }
        public string? metadataValue { get; set; }
        public string? productId { get; set; }
        public string? activationAppVersion { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? lastSeenAt { get; set; }
        public string? query { get; set; }
    }
}
