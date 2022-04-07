using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Api.Contracts.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CodevDone.CQRS.Api.Filters
{
    public class ValidateModelGuidAttribute : ActionFilterAttribute
    {
        private readonly string _key;

        public ValidateModelGuidAttribute(string key)
        {
            _key = key;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue(_key , out var value))
            {
                return;
            }

            if (Guid.TryParse(value?.ToString(), out var guid))
            {
                return;
            }

            var apiError = new ErrorResponse();
            apiError.StatusCode = 400;
            apiError.StatusPhrase = "Bad Request CuStOm validate model guid. . ";
            apiError.Timestamp = DateTime.Now;
            apiError.Errors.Add($"the identifier for {_key} is not a valid guid");
            context.Result= new ObjectResult(apiError);
           
        }

    }
}