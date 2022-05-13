using CryptlexDotNet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptlexDotNet.Exceptions
{
    public class CryptlexException : Exception
    {
        public Error? CryptlexError { get; set; }

        public bool HasCryptlexError => CryptlexError is not null;
        
        public CryptlexException(Error error = null!) : base()
        {
            CryptlexError = error;
        }

        public CryptlexException(string? message, Error error = null!)
            : base(message)
        {
            CryptlexError = error;
        }

        public CryptlexException(string? message, Exception? innerException, Error error = null!)
            : base(message, innerException)
        {
            CryptlexError = error;
        }
    }
}
