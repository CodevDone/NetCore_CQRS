using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodevDone.CQRS.Api.Contracts.Common;
using CodevDone.CQRS.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodevDone.CQRS.Api.Controllers.V1
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiError = new ErrorResponse();

            if (errors.Any(e => e.Code == ErrorCode.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound);
                apiError.StatusCode = 404;
                apiError.StatusPhrase = "Not Found";
                apiError.Errors.Add(error.Message);
                apiError.Timestamp = DateTime.Now;
                return NotFound(apiError);
            }

            apiError.StatusCode = 400;
            apiError.StatusPhrase = "Bad Request";
            apiError.Timestamp = DateTime.Now;
            // foreach (var er in errors)
            // {
            //     apiError.Errors.Add(er.Message);
            // }
            errors.ForEach(e => apiError.Errors.Add(e.Message));
            return StatusCode(400, apiError);
        }

    }
}