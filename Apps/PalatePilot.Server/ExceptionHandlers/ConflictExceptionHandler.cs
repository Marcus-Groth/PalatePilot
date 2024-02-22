using System;
using Microsoft.AspNetCore.Diagnostics;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Helper;

namespace PalatePilot.Server.ExceptionHandlers
{
    public class ConflicExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ConflictException conflictException)
            {    
                // Generate error response
                var response = new ErrorResponse<string>
                (
                    statusCode: StatusCodes.Status409Conflict,
                    title: "Conflict",
                    errors: conflictException.Message 
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