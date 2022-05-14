namespace Cryptlex.Net.Accounts
{
    public class AccountLoginGoogleData
    {
        public string? companyId { get; set; }
        public string email { get; set; }
        public string idToken { get; set; }

        public AccountLoginGoogleData(string email, string idToken)
        {
            this.email = email;
            this.idToken = idToken;
        }
    }
}
