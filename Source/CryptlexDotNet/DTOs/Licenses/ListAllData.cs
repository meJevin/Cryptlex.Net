using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.DTOs.Licenses
{
    public class ListAllData
    {
        public int? page;
        public int? limit;
        public string? sort;
        public string? productId;
        public string? userId;
        public string? resellerId;
        public string? userEmail; // make this objectable
        public string? userCompany; // make this objectable
        public string? key;
        public bool? revoked;
        public bool? suspended;
        public string? type;
        public int? validity;
        public int? allowedActivations;
        public int? allowedDeactivations;
        public int? totalActivations;
        public int? totalDeactivations;
        public bool? allowVmActivation;
        public bool? userLocked;
        public bool? expired;
        public DateTime? createdAt;
        public string? tag;
        public string? metadataKey; // make this objectable
        public string? metadataValue; // make this objectable
        public string? query;
    }
}
