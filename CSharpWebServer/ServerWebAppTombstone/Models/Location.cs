using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerWebAppTombstone.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VerboseDescription { get; set; }
        public int? East { get; set; }
        public int? West { get; set; }
        public int? North { get; set; }
        public int? South { get; set; }
        public List<Item> ItemList { get; set; }
        

        public void RemoveItem(Item item)
        {
            ItemList.Remove(item);
        }

        public string LocationQuery()
        {

            return $"SELECT * FROM location WHERE id = {Id}";
           
        }
        
        
    }

    
}
