using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class IncrementActivationUsageData
    {
        public long increment { get; set; }
        public string activationId { get; set; }

        public IncrementActivationUsageData(long increment, string activationId)
        {
            this.increment = increment;
            this.activationId = activationId;
        }
    }
}
