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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string? company { get; set; }
        public bool? allowCustomerPortalAccess { get; set; }
        public List<UserMetadataRequestModel>? metadata { get; set; }
        public List<string>? tags { get; set; }
        public bool? googleSsoEnabled { get; set; }
        public bool? twoFactorEnabled { get; set; }
        public string? twoFactorCode { get; set; }

        public UpdateCurrentUserData(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
    }
}
