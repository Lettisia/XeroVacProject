using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroVacProjectConsole.Models
{
    abstract class Item
    { 
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int? locationId { get; set; }
        public bool isVisible { get; set; }

        public abstract string Interact(Item i);
    }
}
