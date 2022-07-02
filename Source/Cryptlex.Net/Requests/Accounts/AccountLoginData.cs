using System.Text.Json.Serialization;
namespace Cryptlex.Net.Accounts
{
    public class AccountLoginData
    {
		[JsonPropertyName("companyId")]
        public string? CompanyId { get; set; }
		[JsonPropertyName("email")]
        public string Email { get; set; }
		[JsonPropertyName("password")]
        public string Password { get; set; }
		[JsonPropertyName("twoFactorCode")]
        public string? TwoFactorCode { get; set; }
		[JsonPropertyName("twoFactorRecoveryCode")]
        public string? TwoFactorRecoveryCode { get; set; }

        public AccountLoginData(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}