using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Exceptions
{
    public class NotFoundException : Exception
    {
        public List<string> Messages { get; }

        public NotFoundException(string message)
            : base(message)
        {
            Messages = new List<string> { message };
        }
        
        public NotFoundException(List<string> messages)
            : base(string.Join("; ", messages))
        {
            Messages = messages ?? new List<string>();
        }
    }
}