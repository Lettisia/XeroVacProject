using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroVacProjectConsole.Models.Components
{
    abstract class Component
    {
        public int x { get; set; }
        public int y { get; set; }
        public string description { get; set; }
    }
}
