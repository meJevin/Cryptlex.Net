using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class ActivationMeterAttributeRequestModel
    {
        public string name { get; set; }
        public int usesIncrement { get; set; }

        protected ActivationMeterAttributeRequestModel()
        {

        }

        public ActivationMeterAttributeRequestModel(string name, int usesIncrement)
        {
            this.name = name;
            this.usesIncrement = usesIncrement;
        }
    }
}
