using System.Text.Json.Serialization;
namespace Cryptlex.Net.Users
{
    public class PasswordResetTokenResponse
    {
		[JsonPropertyName("resetPasswordToken")]
        public string? ResetPasswordToken { get; set; }
    }
}