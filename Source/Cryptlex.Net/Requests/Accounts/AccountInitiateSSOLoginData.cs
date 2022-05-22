namespace Cryptlex.Net.Accounts
{
    public class AccountInitiateSSOLoginData
    {
        public string returnUrl { get; set; }

        public AccountInitiateSSOLoginData(string returnUrl)
        {
            this.returnUrl = returnUrl;
        }
    }
}
