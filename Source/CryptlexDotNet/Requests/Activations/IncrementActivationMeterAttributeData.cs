using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Activations
{
    public class IncrementActivationMeterAttributeData
    {
        public long increment { get; set; }
        public string activationId { get; set; }

        public IncrementActivationMeterAttributeData(long increment, string activationId)
        {
            this.increment = increment;
            this.activationId = activationId;
        }
    }
}
