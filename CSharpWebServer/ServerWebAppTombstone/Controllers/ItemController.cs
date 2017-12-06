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
        public string Testingiteminteraction()
        {
            AddItems();
            //more complex in future
            int id1 = 1;
            int id2 = 2;
            Item i1 = world.ItemList.Where(x => x.Id == 1).First();
            Item i2 = world.ItemList.Where(x => x.Id == 2).First();
            return i1.Interact(i2);
            
        }


        [HttpGet]
        [Route("api/[controller]/additems")]
        public string AddItems()
        {
            var key = new Key();
            key.Id = 1;
            world.ItemList.Add(key);
            var door = new Door();
            door.Id = 2;
            world.ItemList.Add(door);
            return "";
        }
    }
}