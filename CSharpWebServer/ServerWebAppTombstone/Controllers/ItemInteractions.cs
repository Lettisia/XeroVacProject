using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerWebAppTombstone.Models.Items;
using ServerWebAppTombstone.Models;

namespace ServerWebAppTombstone.Controllers
{
    public static class ItemInteractions
    {
        private static World world = World.GetInstance();

        
        public static string DoorKey(Door d, Key k)
        {
            var temp = world.ItemList.Remove(k);
            int i = world.ItemList.Count();
            var temp1 = world.ItemList;
            int j = world.ItemList.Count();

            return "Opened";
        }




    }
}
