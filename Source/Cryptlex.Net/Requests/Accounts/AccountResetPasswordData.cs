namespace Cryptlex.Net.Accounts
{
    public class AccountResetPasswordData
    {
        public string? companyId { get; set; }
        public string email { get; set; }

        public AccountResetPasswordData(string email)
        {
            this.email = email;
        }
    }
}
