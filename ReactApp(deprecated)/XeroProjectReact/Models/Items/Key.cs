using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroProjectReact.Controllers;

namespace XeroProjectReact.Models.Items
{
    class Key : Item
    {
        override public string Interact(Item item)
        {
            if(item is Door)
            {
                return ItemInteractions.DoorKey((Door)item,this);
            }
            return "";
        }
         private string Interact(Door d)
        {
            return d.Interact(this);
        }
    }
}
