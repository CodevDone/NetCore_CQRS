using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Api.Contracts.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CodevDone.CQRS.Api.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var apiError = new ErrorResponse();
                apiError.StatusCode = 400;
                apiError.StatusPhrase = "Bad Request CuStOm. . ";
                apiError.Timestamp = DateTime.Now;
                apiError.Errors.AddRange(context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                // var errors = context.ModelState.AsEnumerable();
                // foreach (var error in errors)
                // {
                //     foreach (var inner in error.Value.Errors)
                //     {
                //         apiError.Errors.Add(inner.ErrorMessage);
                //     }
                // }

                context.Result = new BadRequestObjectResult(apiError);
                // TODO: Make sure asp Net Core dosn't override our action result body
            }

        }


    }
}