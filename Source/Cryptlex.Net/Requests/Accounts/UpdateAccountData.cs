using System.Text.Json.Serialization;
using Cryptlex.Net.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Accounts
{
    public class UpdateAccountData
    {
		[JsonPropertyName("email")]
        public string? Email { get; set; }
		[JsonPropertyName("company")]
        public string? Company { get; set; }
		[JsonPropertyName("companyId")]
        public string? CompanyId { get; set; }
		[JsonPropertyName("customDomain")]
        public string? CustomDomain { get; set; }
		[JsonPropertyName("website")]
        public string? Website { get; set; }
		[JsonPropertyName("logoUrl")]
        public string? LogoUrl { get; set; }
		[JsonPropertyName("faviconUrl")]
        public string? FaviconUrl { get; set; }
		[JsonPropertyName("googleClientId")]
        public string? GoogleClientId { get; set; }
    }
}