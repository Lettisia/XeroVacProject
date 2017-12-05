using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroVacProjectConsole.Controllers;

namespace XeroVacProjectConsole.Models.Items
{
    class Key : Item
    {
        override public string Interact(Item item)
        {
            if(item is Door)
            {
                return Interactions.DoorInteractKey((Door)item,this);
            }
            return "";
        }
    }
}
