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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string company { get; set; }
        public string companyId { get; set; }

        public CreateAccountData(
            string firstName, string lastName, string email,
            string password, string company, string companyId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.company = company;
            this.companyId = companyId;
        }
    }
}
