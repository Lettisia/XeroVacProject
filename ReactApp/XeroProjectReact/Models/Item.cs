using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XeroProjectReact.Models.Items;

namespace XeroProjectReact.Models
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
                    return new Key();
                case (2):
                    return new Door();
                case (3):
                    return new Door();
                case (4):
                    return new Door();
                case (5):
                    return new Door();
                case (6):
                    return new Door();
                case (7):
                    return new Door();
                default:
                    return null;

            }
            //return new Key();
        }
    }
}
