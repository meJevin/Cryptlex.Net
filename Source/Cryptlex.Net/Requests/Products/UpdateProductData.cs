namespace Cryptlex.Net.Products
{
    public class UpdateProductData
    {
        public string? name { get; set; }
        public string? displayName { get; set; }
        public string? description { get; set; }
        public List<string>? emailTemplates { get; set; }
        public string? licensePolicyId { get; set; }
        public string? trialPolicyId { get; set; }
        public List<ProductMetadataRequestModel>? metadata { get; set; } 
    }
}
