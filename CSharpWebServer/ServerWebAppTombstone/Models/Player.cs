using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerWebAppTombstone.Models;

namespace ServerWebAppTombstone.Models
{
    public class Player
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Location CurrentLocation { get; set; }
        public List<Item> Inventory { get; set; }

        public Player()
        {
            Inventory = new List<Item>();
        }


        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

        internal void RemoveItem(Item item)
        {
            Inventory.Remove(item);
        }
    }

    
}
