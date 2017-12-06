using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerWebAppTombstone.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string CharacterName { get; set; }

        public string CharacterDescription { get; set; }

        public int? LocationId { get; set; }

        public string   CharacterQuery()
        {

            return $"SELECT * FROM character WHERE id = {Id}";

        }
    }
}
