namespace Cryptlex.Net.LicensePolicies
{
    public class CreateLicensePolicyData
    {
        public string name { get; set; }
        public string description { get; set; }

        protected CreateLicensePolicyData()
        {

        }

        public CreateLicensePolicyData(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
