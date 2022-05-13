using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.DTOs.Licenses
{
    public class ExtendData
    {
        public int extensionLength { get; set; }

        protected ExtendData()
        {

        }

        public ExtendData(int extensionLength)
        {
            this.extensionLength = extensionLength;
        }
    }
}
