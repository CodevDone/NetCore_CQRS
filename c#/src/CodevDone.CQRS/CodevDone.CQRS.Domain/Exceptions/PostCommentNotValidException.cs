using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Domain.Exceptions
{
    public class PostCommentNotValidException : NotValidException
    {
        internal PostCommentNotValidException() { }

        internal PostCommentNotValidException(string message) : base(message) { }

        internal PostCommentNotValidException(string message, Exception innerException) : base(message, innerException) { }
    }
}