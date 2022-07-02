using System.Text.Json.Serialization;
namespace Cryptlex.Net.Users.Current
{
    public class TwoFactorAuthenticationRecoveryCodeResponse
    {
		[JsonPropertyName("recoveryCodes")]
        public List<string>? RecoveryCodes { get; set; }
    }
}