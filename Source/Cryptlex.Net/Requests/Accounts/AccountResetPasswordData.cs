using System.Text.Json.Serialization;
namespace Cryptlex.Net.Accounts
{
    public class AccountResetPasswordData
    {
		[JsonPropertyName("companyId")]
        public string? CompanyId { get; set; }
		[JsonPropertyName("email")]
        public string Email { get; set; }

        public AccountResetPasswordData(string email)
        {
            this.Email = email;
        }
    }
}