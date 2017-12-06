using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServerWebAppTombstone.Models.Items;

namespace ServerWebAppTombstone.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? LocationId { get; set; }
        public bool IsVisible { get; set; }


        public abstract string Interact(Item i);
        


        public static Item GenerateChildOfItemFromId(int id)
        {
            switch (id)
            {
                case (1):
                    return new Herb();
                case (2):
                    return new Coin();
                case (3):
                    return new Gun();
                case (4):
                    return new Key();
                case (5):
                    return new Door();
                default:
                    return null;

            }
            //return new Key();
        }
    }
}
