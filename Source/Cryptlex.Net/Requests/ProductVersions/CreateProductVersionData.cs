using Cryptlex.Net.Products;

namespace Cryptlex.Net.ProductVersions
{
    public class CreateProductVersionData
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string description { get; set; }
        public string productId { get; set; }
        public List<ProductVersionFeatureFlagRequestModel>? featureFlags { get; set; }

        public CreateProductVersionData(
            string name, string displayName, 
            string description, string productId)
        {
            this.name = name;
            this.displayName = displayName;
            this.description = description;
            this.productId = productId;
        }
    }
}
