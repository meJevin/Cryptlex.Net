using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Activations
{
    public class ActivationMeterAttributeRequestModel
    {
        public string Name { get; set; }
        public int UsesIncrement { get; set; }

        protected ActivationMeterAttributeRequestModel()
        {

        }

        public ActivationMeterAttributeRequestModel(string name, int usesIncrement)
        {
            this.Name = name;
            this.UsesIncrement = usesIncrement;
        }
    }
}
