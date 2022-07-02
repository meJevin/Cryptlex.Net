using System.Text.Json.Serialization;
namespace Cryptlex.Net.Accounts
{
    public class AccountLoginGoogleData
    {
		[JsonPropertyName("companyId")]
        public string? CompanyId { get; set; }
		[JsonPropertyName("email")]
        public string Email { get; set; }
		[JsonPropertyName("idToken")]
        public string IdToken { get; set; }

        public AccountLoginGoogleData(string email, string idToken)
        {
            this.Email = email;
            this.IdToken = idToken;
        }
    }
}