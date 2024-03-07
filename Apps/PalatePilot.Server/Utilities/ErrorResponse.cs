
using System;
namespace PalatePilot.Server.Helper
{
    public class ErrorResponse<T>
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public T Errors { get; set; }

        public ErrorResponse(int statusCode, string title, T errors)
        {
            StatusCode = statusCode;
            Title = title;
            Errors = errors;
        }
    }
}