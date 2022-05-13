using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Entities
{
    public class MeterAttribute
    {
        public string name { get; set; }
        public int allowedUses { get; set; }
        public bool visible { get; set; }
        public bool floating { get; set; }
    }
}
