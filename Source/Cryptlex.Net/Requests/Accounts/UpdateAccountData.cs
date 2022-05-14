using Cryptlex.Net.Entities;
using Cryptlex.Net.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Accounts
{
    public class UpdateAccountData
    {
        public string? email { get; set; }
        public string? company { get; set; }
        public string? companyId { get; set; }
        public string? customDomain { get; set; }
        public string? website { get; set; }
        public string? logoUrl { get; set; }
        public string? faviconUrl { get; set; }
        public string? googleClientId { get; set; }
    }
}
