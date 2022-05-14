namespace Cryptlex.Net.Users
{
    public class CreateUserData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string? company { get; set; }
        public bool? allowCustomerPortalAccess { get; set; }
        public List<UserMetadataRequestModel>? metadata { get; set; }
        public List<string>? tags { get; set; }
        public string password { get; set; }
        public string? role { get; set; }

        public CreateUserData(string firstName, string lastName, string email, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
        }
    }
}
