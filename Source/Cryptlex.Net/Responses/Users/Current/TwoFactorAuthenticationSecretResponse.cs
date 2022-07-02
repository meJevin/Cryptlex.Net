using System.Text.Json.Serialization;
namespace Cryptlex.Net.Users.Current
{
    public class TwoFactorAuthenticationSecretResponse
    {
		[JsonPropertyName("email")]
        public string? Email { get; set; }
		[JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}