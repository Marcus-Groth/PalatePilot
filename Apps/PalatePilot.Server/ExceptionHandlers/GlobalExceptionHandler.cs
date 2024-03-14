using System;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Helper;

namespace PalatePilot.Server.ExceptionHandlers
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(
            RequestDelegate next,
            ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(BadRequestException exception)
            {
                _logger.LogError(exception, "Bad Request Exception occurred: {Message}", exception.Message);
                 var response = new ErrorResponse<string>
                (
                    statusCode: StatusCodes.Status400BadRequest,
                    title: "BadRequest",
                    errors: exception.Message 
                );

                context.Response.StatusCode =
                    StatusCodes.Status400BadRequest;

                await context.Response.WriteAsJsonAsync(response);
            }
            catch(NotFoundException exception)
            {
                _logger.LogError(exception, "NotFound Exception occurred: {Message}", exception.Message);
                 var response = new ErrorResponse<string>
                (
                    statusCode: StatusCodes.Status404NotFound,
                    title: "NotFound",
                    errors: exception.Message 
                );

                context.Response.StatusCode =
                    StatusCodes.Status404NotFound;

                await context.Response.WriteAsJsonAsync(response);
            }
            catch(ConflictException exception)
            {
                _logger.LogError(exception, "Conflict Exception occurred: {Message}", exception.Message);
                 var response = new ErrorResponse<string>
                (
                    statusCode: StatusCodes.Status409Conflict,
                    title: "Conflict",
                    errors: exception.Message 
                );

                context.Response.StatusCode =
                    StatusCodes.Status409Conflict;

                await context.Response.WriteAsJsonAsync(response);
            }
            catch(UnauthorizedException exception)
            {
                _logger.LogError(exception, "Unauthorized Exception occurred: {Message}", exception.Message);
                 var response = new ErrorResponse<string>
                (
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: "Unauthorized",
                    errors: exception.Message 
                );

                context.Response.StatusCode =
                    StatusCodes.Status401Unauthorized;

                await context.Response.WriteAsJsonAsync(response);
            }
            catch(ForbiddenException exception)
            {
                _logger.LogError(exception, "Forbidden Exception occurred: {Message}", exception.Message);
                 var response = new ErrorResponse<string>
                (
                    statusCode: StatusCodes.Status403Forbidden,
                    title: "Forbidden",
                    errors: exception.Message 
                );

                context.Response.StatusCode =
                    StatusCodes.Status403Forbidden;

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}