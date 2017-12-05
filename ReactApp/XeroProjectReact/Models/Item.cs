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
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int? locationId { get; set; }
        public bool isVisible { get; set; }

        // public Item(int id)
        // {
        //
        // }


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
