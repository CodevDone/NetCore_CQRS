using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Domain.Exceptions
{
    public class NotValidException : Exception
    {
        public List<string> ValidationErrors { get; }
        internal NotValidException()
        {
            ValidationErrors = new List<string>();
        }

        internal NotValidException(string message) : base(message)
        {
            ValidationErrors = new List<string>();
        }
        internal NotValidException(string message, Exception innerException) : base(message, innerException)
        {
            ValidationErrors = new List<string>();
        }

    }
}