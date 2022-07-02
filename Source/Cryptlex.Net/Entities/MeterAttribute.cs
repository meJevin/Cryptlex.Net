using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Entities
{
    public class MeterAttribute
    {
        public string Name { get; set; }
        public int AllowedUses { get; set; }
        public bool Visible { get; set; }
        public bool Floating { get; set; }
    }
}