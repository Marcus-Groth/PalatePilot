using System;
namespace PalatePilot.Server.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<string> Messages { get; }

        public BadRequestException(string message)
            : base(message)
        {
            Messages = new List<string> { message };
        }
        
        public BadRequestException(List<string> messages)
            : base(string.Join("; ", messages))
        {
            Messages = messages ?? new List<string>();
        }
    }
}