using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Users.Current
{
    public class ListCurrentUserLicensesData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? releaseId { get; set; }
        public string? query { get; set; }
    }
}
