using System.Text.Json.Serialization;
using Cryptlex.Net.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Users.Current
{
    public class UpdateCurrentUserData
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
		[JsonPropertyName("googleSsoEnabled")]
        public bool? GoogleSsoEnabled { get; set; }
		[JsonPropertyName("twoFactorEnabled")]
        public bool? TwoFactorEnabled { get; set; }
		[JsonPropertyName("twoFactorCode")]
        public string? TwoFactorCode { get; set; }

        public UpdateCurrentUserData(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
    }
}