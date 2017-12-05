using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroProjectReact.Models;

namespace XeroProjectReact.Models
{
    public class Player
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Location CurrentLocation { get; set; }
        public List<Item> Inventory { get; set; }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

       
    }

    
}
