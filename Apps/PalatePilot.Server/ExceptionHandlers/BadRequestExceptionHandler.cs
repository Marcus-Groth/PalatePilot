using System;
using Microsoft.AspNetCore.Diagnostics;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Helper;

namespace PalatePilot.Server.ExceptionHandlers
{
    public class BadRequestExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is BadRequestException badRequestException)
            {    
                // Generate error response
                var response = new ErrorResponse<string>
                (
                    statusCode: StatusCodes.Status400BadRequest,
                    title: "BadRequest",
                    errors: badRequestException.Message 
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