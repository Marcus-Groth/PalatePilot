using System;
namespace PalatePilot.Server.Exceptions
{
    public class ConflictException : Exception
    {
        public List<string> Messages { get; }

        public ConflictException(string message)
            : base(message)
        {
            Messages = new List<string> { message };
        }
        
        public ConflictException(List<string> messages)
            : base(string.Join("; ", messages))
        {
            Messages = messages ?? new List<string>();
        }
    }
}