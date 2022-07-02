using System.Text.Json.Serialization;
using Cryptlex.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Accounts
{
    public class CreateAccountData
    {
		[JsonPropertyName("firstName")]
        public string FirstName { get; set; }
		[JsonPropertyName("lastName")]
        public string LastName { get; set; }
		[JsonPropertyName("email")]
        public string Email { get; set; }
		[JsonPropertyName("password")]
        public string Password { get; set; }
		[JsonPropertyName("company")]
        public string Company { get; set; }
		[JsonPropertyName("companyId")]
        public string CompanyId { get; set; }

        public CreateAccountData(
            string firstName, string lastName, string email,
            string password, string company, string companyId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Company = company;
            this.CompanyId = companyId;
        }
    }
}