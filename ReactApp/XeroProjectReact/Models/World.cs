using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeroVacProjectConsole.Models;

namespace XeroProjectReact.Models
{
    public class World
    {
        public List<Item> ItemList { get; set; }

        public List<Character> CharacterList { get; set; }

        public List<Location> LocationList { get; set; }

        public Player ThePlayer { get; set; }
    }
}
