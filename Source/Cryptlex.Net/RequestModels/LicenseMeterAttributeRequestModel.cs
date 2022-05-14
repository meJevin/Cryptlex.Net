using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.RequestModels
{
    public class LicenseMeterAttributeRequestModel
    {
        public string name { get; set; }
        public int allowedUses { get; set; }
        public bool? visible { get; set; }
        public bool? floating { get; set; }

        protected LicenseMeterAttributeRequestModel()
        {

        }

        public LicenseMeterAttributeRequestModel(string name, int allowedUses)
        {
            this.name = name;
            this.allowedUses = allowedUses;
        }
    }
}
