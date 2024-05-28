using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Domains
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}