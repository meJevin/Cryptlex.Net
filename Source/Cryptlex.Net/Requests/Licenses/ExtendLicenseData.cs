using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Licenses
{
    public class ExtendLicenseData
    {
        public int extensionLength { get; set; }

        public ExtendLicenseData(int extensionLength)
        {
            this.extensionLength = extensionLength;
        }
    }
}
