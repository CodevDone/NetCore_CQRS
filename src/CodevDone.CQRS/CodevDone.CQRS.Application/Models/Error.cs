using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodevDone.CQRS.Application.Models
{
    public class Error
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; }
    }
}