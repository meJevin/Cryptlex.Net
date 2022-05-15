using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.PersonalAccessTokens
{
    public class ListPersonalAccessTokensData
    {
        public int? page { get; set; }
        public int? limit { get; set; }
        public string? sort { get; set; }
        public string? query { get; set; }                                                               
    }
}
