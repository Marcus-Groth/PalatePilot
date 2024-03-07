using System;
using Microsoft.AspNetCore.Diagnostics;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Helper;

namespace PalatePilot.Server.ExceptionHandlers
{
    public class UnauthorizedExceptionHandler : IExceptionHandler
    {
         public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is UnauthorizedException unauthorizedException)
            {    
                // Generate error response
                var response = new ErrorResponse<object>
                (
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: "Unauthorized",
                    errors: unauthorizedException.Message 
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