using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Domain.Exceptions
{
    public class PostNotValidException : NotValidException
    {
        internal PostNotValidException() { }

        internal PostNotValidException(string message) : base(message) { }

        internal PostNotValidException(string message, Exception innerException) : base(message, innerException) { }
    }
}