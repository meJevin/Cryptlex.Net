using System.Text.Json.Serialization;
namespace Cryptlex.Net.Users
{
    public class ResetUserPasswordData
    {
		[JsonPropertyName("token")]
        public string Token { get; set; }
		[JsonPropertyName("newPassword")]
        public string NewPassword { get; set; }

        public ResetUserPasswordData(string token, string newPassword)
        {
            this.Token = token;
            this.NewPassword = newPassword;
        }
    }
}