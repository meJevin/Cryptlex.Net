using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Core
{
    public interface ICryptlexAccessTokenFactory
    {
        Task<string> GetAccessTokenAsync();
    }
}
