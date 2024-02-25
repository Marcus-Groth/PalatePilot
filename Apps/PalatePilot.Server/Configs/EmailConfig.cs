using System;
namespace PalatePilot.Server.Configs
{
    public class EmailConfig
    {
        public string Server { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}