using Cryptlex.Net.Products;

namespace Cryptlex.Net.ProductVersions
{
    public class UpdateProductVersionData
    {
        public string? name { get; set; }
        public string? displayName { get; set; }
        public string? description { get; set; }
        public string? productId { get; set; }
        public List<ProductVersionFeatureFlagRequestModel>? featureFlags { get; set; }
    }
}
