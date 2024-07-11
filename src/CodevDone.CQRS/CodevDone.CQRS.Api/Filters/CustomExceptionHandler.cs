using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Api.Contracts.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CodevDone.CQRS.Api.Filters
{
    public class CustomExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var apiError = new ErrorResponse();
            apiError.StatusCode = 500;
            apiError.StatusPhrase = "Internal CuStOm Server Error ";
            apiError.Timestamp = DateTime.Now;
            apiError.Errors.AddRange(context.Exception.Message.Split('\n'));

            context.Result = new JsonResult(apiError) { StatusCode = 500 };

        }



    }
}