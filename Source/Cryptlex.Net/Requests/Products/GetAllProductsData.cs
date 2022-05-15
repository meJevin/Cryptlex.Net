namespace Cryptlex.Net.Products
{
    public class GetAllProductsData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? name { get; set; }
        public string? metadataKey { get; set; }
        public string? metadataValue { get; set; }
        public string? query { get; set; }
    }
}
