using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Licenses
{
    public class ExtendLicenseData
    {
		[JsonPropertyName("extensionLength")]
        public int ExtensionLength { get; set; }

        public ExtendLicenseData(int extensionLength)
        {
            this.ExtensionLength = extensionLength;
        }
    }
}