using System.Text.Json.Serialization;
namespace Cryptlex.Net.Products
{
    public class CreateProductData
    {
		[JsonPropertyName("name")]
        public string Name { get; set; }
		[JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
		[JsonPropertyName("description")]
        public string Description { get; set; }
		[JsonPropertyName("emailTemplates")]
        public List<string>? EmailTemplates { get; set; }
		[JsonPropertyName("licensePolicyId")]
        public string LicensePolicyId { get; set; }
		[JsonPropertyName("trialPolicyId")]
        public string? TrialPolicyId { get; set; }
		[JsonPropertyName("metadata")]
        public List<ProductMetadataRequestModel>? Metadata { get; set; }

        public CreateProductData(
            string name, string displayName,
            string description, string licensePolicyId)
        {
            this.Name = name;
            this.DisplayName = displayName;
            this.Description = description;
            this.LicensePolicyId = licensePolicyId;
        }
    }
}