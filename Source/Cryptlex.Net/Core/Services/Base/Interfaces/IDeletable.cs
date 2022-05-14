using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptlex.Net.Core.Services.Base
{
    public interface IDeletable<T>
    {
        Task DeleteAsync(string id);
    }
}
