using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeroProjectReact.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? LocationId { get; set; }
        public bool IsVisible { get; set; }

        public static Item ReadItemIntoChildClass()
        {

            return new Item();
        }
    }
}
