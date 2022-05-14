namespace Cryptlex.Net.Accounts
{
    public class AccountLoginData
    {
        public string? companyId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string? twoFactorCode { get; set; }
        public string? twoFactorRecoveryCode { get; set; }

        public AccountLoginData(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
