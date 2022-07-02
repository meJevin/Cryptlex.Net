using System.Text.Json.Serialization;
namespace Cryptlex.Net.Accounts
{
    public class AccountInitiateSSOLoginData
    {
		[JsonPropertyName("returnUrl")]
        public string ReturnUrl { get; set; }

        public AccountInitiateSSOLoginData(string returnUrl)
        {
            this.ReturnUrl = returnUrl;
        }
    }
}