namespace Cryptlex.Net.Accounts
{
    public class UpdateAccountPlanData
    {
        public string planId { get; set; }

        public UpdateAccountPlanData(string planId)
        {
            this.planId = planId;
        }
    }
}
