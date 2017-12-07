using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerWebAppTombstone.Controllers;

namespace ServerWebAppTombstone.Models.Items
{
    public class Key : Item
    {
        override public string Interact(Item item)
        {
            if(item is Door)
            {
                return ItemInteractions.DoorKey((Door)item,this);
            }
            return "Nothing interesting happened";
        }

    }
}
