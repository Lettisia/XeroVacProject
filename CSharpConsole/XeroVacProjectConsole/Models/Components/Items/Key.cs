using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroVacProjectConsole.Models.Components.Items
{
    class Key
    {
        public void Interact(Door d)
        {
            d.Interact(this);
        }
    }
}
