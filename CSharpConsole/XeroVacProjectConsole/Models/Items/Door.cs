using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroVacProjectConsole.Controllers;

namespace XeroVacProjectConsole.Models.Items
{
    class Door : Item
    {
        

        override public string Interact(Item item)
        {
            if(item is Key)
            {
                return Interactions.DoorInteractKey(this, (Key)item);
            }
            return "";
        }
    }
}
