using Cryptlex.Net.RequestModels;

namespace Cryptlex.Net.Users
{
    public class UpdateUserData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string? company { get; set; }
        public bool? allowCustomerPortalAccess { get; set; }
        public List<UserMetadataRequestModel>? metadata { get; set; }
        public List<string>? tags { get; set; }
        public string? role { get; set; }

        public UpdateUserData(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
    }
}
