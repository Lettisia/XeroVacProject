using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerWebAppTombstone.Controllers;

namespace ServerWebAppTombstone.Models.Items
{
    public class Door : Item
    {

        override public string Interact(Item item)
        {
            if(item is Key)
            {
                return ItemInteractions.DoorKey(this, (Key)item);
            }
            //Item item = location.items.Remove(
            return "Nothing interesting happened";
        }
    }
}
