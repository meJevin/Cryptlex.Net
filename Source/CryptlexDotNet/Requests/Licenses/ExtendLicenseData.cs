using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Licenses
{
    public class ExtendLicenseData
    {
        public int extensionLength { get; set; }

        protected ExtendLicenseData()
        {

        }

        public ExtendLicenseData(int extensionLength)
        {
            this.extensionLength = extensionLength;
        }
    }
}
