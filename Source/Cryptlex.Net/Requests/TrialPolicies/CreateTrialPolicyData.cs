namespace Cryptlex.Net.TrialPolicies
{
    public class CreateTrialPolicyData
    {
        public string name { get; set; }
        public string description { get; set; }

        protected CreateTrialPolicyData()
        {

        }

        public CreateTrialPolicyData(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
