using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.DTOs.Licenses
{
    public class ExportAllData
    {
        public string? productId { get; set; }
        public string? userId { get; set; }
        public string? email { get; set; }
        public string? query { get; set; }
    }
}
