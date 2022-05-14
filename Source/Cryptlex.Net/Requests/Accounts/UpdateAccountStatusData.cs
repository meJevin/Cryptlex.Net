namespace Cryptlex.Net.Accounts
{
    public class UpdateAccountStatusData
    {
        public string status { get; set; }

        public UpdateAccountStatusData(string status)
        {
            this.status = status;
        }
    }
}
