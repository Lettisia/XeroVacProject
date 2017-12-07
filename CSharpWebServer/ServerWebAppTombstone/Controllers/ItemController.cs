using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerWebAppTombstone.Models;
using ServerWebAppTombstone.Models.Items;

namespace ServerWebAppTombstone.Controllers
{
    public class ItemController : Controller
    {
        private World world = World.GetInstance(); 
        public IActionResult Index()
        {
            return View();
        }



        

        [HttpGet]
        [Route("api/[controller]/testing")]
        //?item1Id=1&onPerson1=true&item2Id=2&onPerson2=true&locationid=1
        public string Testingiteminteraction(int item1Id, bool onPerson1, int item2Id, bool onPerson2, int locationId)
        {
            AddItems();
            //more complex in future, take in arguments

            Item i1 = GetItem(item1Id, onPerson1, locationId);
            Item i2 = GetItem(item2Id,onPerson2,locationId);
            return i1.Interact(i2);
            
        }

        private Item GetItem(int itemId, bool onPerson, int locationId)
        {
            if(onPerson)
            {
                return world.ThePlayer.Inventory.Where(item => item.Id == itemId).First();
            }
            else

            { 
                return GetLocation(locationId).ItemList.Where(item => item.Id == itemId).First();

            }
        }

        private Location GetLocation(int id)
        {
            return world.LocationList.Where(loc => loc.Id == id).First();
        }

        //THIS IS TEMPORARY
        [HttpGet]
        [Route("api/[controller]/additems")]
        public string AddItems()
        {
            var key = new Key();
            key.Id = 1;
            world.ThePlayer.Inventory.Add(key);
            var door = new Door();
            door.Id = 2;
            world.ItemList.Add(door);
            world.LocationList.Where(l => l.Id == 1).First().Additem(door);
            return "";
        }


        //move this method somewhere else later
        public IEnumerable<Item> GetEnvironmentItems(int locId)
        {
            var ItemList = new List<Item>();

            var location = world.LocationList.Where(loc => loc.Id == locId).First();

            ItemList = location.ItemList.Where(item => item.IsVisible).ToList();

            return ItemList;
        }

        public IEnumerable<Item> GetInventory()
        {
            return world.ThePlayer.Inventory;
        }
    }
}