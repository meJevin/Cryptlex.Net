using System.Text.Json.Serialization;
namespace Cryptlex.Net.Accounts
{
    public class UpdateAccountPlanData
    {
		[JsonPropertyName("planId")]
        public string PlanId { get; set; }

        public UpdateAccountPlanData(string planId)
        {
            this.PlanId = planId;
        }
    }
}