using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Licenses
{
    public class GetAllLicensesData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? productId { get; set; }
        public string? userId { get; set; }
        public string? resellerId { get; set; }
        public string? userEmail { get; set; }
        public string? userCompany { get; set; }
        public string? key { get; set; }
        public bool? revoked { get; set; }
        public bool? suspended { get; set; }
        public string? type { get; set; }
        public int? validity { get; set; }
        public int? allowedActivations { get; set; }
        public int? allowedDeactivations { get; set; }
        public int? totalActivations { get; set; }
        public int? totalDeactivations { get; set; }
        public bool? allowVmActivation { get; set; }
        public bool? userLocked { get; set; }
        public bool? expired { get; set; }
        public DateTime? createdAt { get; set; }
        public string? tag { get; set; }
        public string? metadataKey { get; set; } 
        public string? metadataValue { get; set; }
        public string? query { get; set; }                                                               
    }
}
