using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroVacProjectConsole.Models.Components.Items;

namespace XeroVacProjectConsole.Controllers
{
    class Interactions
    {
        public string Interact(Door d, Key k)
        {
            //open door
            return "xyz";
        } public void Interact(Key k, Door d) { Interact(d, k); }







    }
}
