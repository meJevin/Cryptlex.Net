namespace Cryptlex.Net.ProductVersions
{
    public class GetAllProductVersionsData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? productId { get; set; }
        public string? name { get; set; }
        public string? query { get; set; }
    }
}
