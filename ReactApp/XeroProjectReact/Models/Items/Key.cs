using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroProjectReact.Models.Items
{
    class Key : Item
    {
        public void Interact(Door d)
        {
            d.Interact(this);
        }
    }
}
