using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Helper;

namespace PalatePilot.Server.ExceptionHandlers
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is NotFoundException notFoundException)
            {    
                // Generate error response
                var response = new ErrorResponse<object>
                (
                    statusCode: StatusCodes.Status404NotFound,
                    title: "Not Found",
                    errors: notFoundException.Message 
                );
                
                // Set response status code and payload
                httpContext.Response.StatusCode = response.StatusCode;
                await httpContext.Response
                    .WriteAsJsonAsync(response, cancellationToken);
                
                return true;
            }

            return false;
        }
    }
}