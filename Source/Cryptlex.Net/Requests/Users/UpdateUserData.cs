using System.Text.Json.Serialization;
namespace Cryptlex.Net.Users
{
    public class UpdateUserData
    {
		[JsonPropertyName("firstName")]
        public string FirstName { get; set; }
		[JsonPropertyName("lastName")]
        public string LastName { get; set; }
		[JsonPropertyName("email")]
        public string Email { get; set; }
		[JsonPropertyName("company")]
        public string? Company { get; set; }
		[JsonPropertyName("allowCustomerPortalAccess")]
        public bool? AllowCustomerPortalAccess { get; set; }
		[JsonPropertyName("metadata")]
        public List<UserMetadataRequestModel>? Metadata { get; set; }
		[JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }
		[JsonPropertyName("role")]
        public string? Role { get; set; }

        public UpdateUserData(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    }
}