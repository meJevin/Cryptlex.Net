namespace Cryptlex.Net.Users
{
    public class ResetUserPasswordData
    {
        public string token { get; set; }
        public string newPassword { get; set; }

        public ResetUserPasswordData(string token, string newPassword)
        {
            this.token = token;
            this.newPassword = newPassword;
        }
    }
}
