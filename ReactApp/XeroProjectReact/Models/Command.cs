using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeroProjectReact.Models
{
    public class Command
    {
        public string Action { get; set; }

        public string Parameter { get; set; }

        public void Execute()
        {
            switch (Action)
            {
                case "CHARDESC":
                case "TRAVEL":
                case "PICKUP":
                case "LOCVERB":
                case "EXAMINEITEM":
                case "USEITEM":
                default:
                    return;
            }
        }

        public string DBQuery()
        {
            switch (Action)
            {
                case "CHARDESC":
                    return $"SELECT characterdescription FROM character WHERE id = {Parameter}";
                default:
                    return "";
            }
        }
    }
}
