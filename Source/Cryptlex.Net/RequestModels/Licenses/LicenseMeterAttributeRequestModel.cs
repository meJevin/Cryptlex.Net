using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Licenses
{
    public class LicenseMeterAttributeRequestModel
    {
        public string Name { get; set; }
        public int AllowedUses { get; set; }
        public bool? Visible { get; set; }
        public bool? Floating { get; set; }

        public LicenseMeterAttributeRequestModel(string name, int allowedUses)
        {
            this.Name = name;
            this.AllowedUses = allowedUses;
        }
    }
}
