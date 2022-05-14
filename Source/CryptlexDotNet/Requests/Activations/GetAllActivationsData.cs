using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Activations
{
    public class GetAllActivationsData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? productId { get; set; }
        public string? licenseId { get; set; }
        public string? metadataKey { get; set; }
        public string? metadataValue { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? lastSyncedAt { get; set; }
        public string? query { get; set; }                                                               
    }
}
