using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public List<string> Messages { get; }

        public UnauthorizedException(string message)
            : base(message)
        {
            Messages = new List<string> { message };
        }
        
        public UnauthorizedException(List<string> messages)
            : base(string.Join("; ", messages))
        {
            Messages = messages ?? new List<string>();
        } 
    }
}