using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeroProjectReact.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int locationId { get; set; }
        public bool isVisible { get; set; }

       // public Item(int id)
       // {
       //
       // }


    }
}
