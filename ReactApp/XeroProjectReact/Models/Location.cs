using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroVacProjectConsole.Models.Components;
using XeroVacProjectConsole.Enums;

namespace XeroProjectReact.Models
{
    public class Location
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string verboseDescription { get; set; }
        public int? east { get; set; }
        public int? west { get; set; }
        public int? north { get; set; }
        public int? south { get; set; }  

        public string LocationQuery()
        {

            return $"SELECT * FROM location WHERE id = {id}";
           
        }

        
        List<Item> items;
        List<Environmental> environmentals;
       
        
    }

    
}
