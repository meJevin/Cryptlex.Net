using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Requests.Users.Current
{
    public class GetAllCurrentUserActivationsData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? licenseId { get; set; }
        public string? query { get; set; }
    }
}
