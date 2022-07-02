using System.Text.Json.Serialization;
namespace Cryptlex.Net.Users
{
    public class UpdateUserPasswordData
    {
		[JsonPropertyName("oldPassword")]
        public string OldPassword { get; set; }
		[JsonPropertyName("newPassword")]
        public string NewPassword { get; set; }

        public UpdateUserPasswordData(string oldPassword, string newPassword)
        {
            this.OldPassword = oldPassword;
            this.NewPassword = newPassword;
        }
    }
}