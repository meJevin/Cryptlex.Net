using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class IncrementActivationUsageResponse
    {
        public string? name { get; set; }
        public int uses { get; set; }
        public int licenseAllowedUses { get; set; }
        public int licenseTotalUses { get; set; }
        public int licenseGrossUses { get; set; }
    }
}
