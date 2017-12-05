using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeroProjectReact.Models
{
    public class Character
    {
        public int id { get; set; }

        public string characterName { get; set; }

        public string characterDescription { get; set; }

        public int? locationId { get; set; }

        public string   CharacterQuery()
        {

            return $"SELECT * FROM character WHERE id = {id}";

        }
    }
}
