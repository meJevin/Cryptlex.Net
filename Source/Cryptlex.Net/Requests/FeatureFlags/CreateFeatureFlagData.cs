namespace Cryptlex.Net.FeatureFlags
{
    public class CreateFeatureFlagData
    {
        public string name { get; set; }
        public string description { get; set; }
        public string productId { get; set; }

        public CreateFeatureFlagData(string name, string description, string productId)
        {
            this.name = name;
            this.description = description;
            this.productId = productId;
        }
    }
}
