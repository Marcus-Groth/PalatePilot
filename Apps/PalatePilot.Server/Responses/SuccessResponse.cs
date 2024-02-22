using System;
using System.ComponentModel.DataAnnotations;
namespace PalatePilot.Server.Models
{
    public class SuccessResponse<T>
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public SuccessResponse(int statusCode, string title, string message, T data)
        {
            StatusCode = statusCode;
            Title = title;
            Message = message;
            Data = data;
        }

        public SuccessResponse(int statusCode, string title, string message)
        {
            StatusCode = statusCode;
            Title = title;
            Message = message;
        }
    }
}