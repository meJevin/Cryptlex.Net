namespace Cryptlex.Net.Users
{
    public class UpdateUserPasswordData
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }

        public UpdateUserPasswordData(string oldPassword, string newPassword)
        {
            this.oldPassword = oldPassword;
            this.newPassword = newPassword;
        }
    }
}
