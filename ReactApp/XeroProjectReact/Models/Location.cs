using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroVacProjectConsole.Models.Components;
using XeroVacProjectConsole.Enums;

namespace XeroVacProjectConsole.Models
{
    class Location
    {
        List<Item> items;
        List<Environmental> environmentals;
        //dir,location id
        Dictionary<int, int> adjacents = new Dictionary<int, int>();
    }

    
}
