﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerWebAppTombstone.Models.Items;

namespace ServerWebAppTombstone.Controllers
{
    class ItemInteractions
    {
        //give it a list of items and locations? should be same as it's memory
        public static string DoorKey(Door d, Key k)
        {
            return "Opened";
        }


    }
}
