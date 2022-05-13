using CryptlexDotNet.Core.Services;
using CryptlexDotNet.DTOs.Licenses;
using CryptlexDotNet.Entities;
using CryptlexDotNet.Exceptions;
using CryptlexDotNet.Util;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryptlexDotNet.Core
{
    public interface ICryptlexClient
    {
        ILicensesService Licenses { get; }
    }

    public class CryptlexClient : ICryptlexClient
    {
        public ILicensesService Licenses { get; init; }

        public CryptlexClient(ILicensesService licenses)
        {
            Licenses = licenses;
        }
    }
}
