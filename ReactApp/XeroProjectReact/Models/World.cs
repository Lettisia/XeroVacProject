using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeroProjectReact.Controllers;

namespace XeroProjectReact.Models
{
    public class World
    {
        public List<Item> ItemList { get; set; }

        public List<Character> CharacterList { get; set; }

        public List<Location> LocationList { get; set; }

        public Player ThePlayer { get; set; }

        public World ()
        {
            DbAccessController dbAccess = new DbAccessController();
            ItemList = dbAccess.InitialiseItems();
            CharacterList = dbAccess.InitialiseCharacter();
            LocationList = dbAccess.InitialiseLocations();
            ThePlayer = new Player();
        }

        public string ExecuteCommand(Command command)
        {
            switch (command.Action)
            {
                case "CHARDESC":
                    return GetCharacterDescription(command.Parameter);
                case "TRAVEL":
                case "PICKUP":
                    return PickUpItem(command.Parameter);
                case "LOCVERB":
                    return GetLocationVerbose(command.Parameter);
                case "EXAMINEITEM":
                    return GetItemDescription(command.Parameter);
                case "USEITEM":
                default:
                    return "invalid";
            }
        }

        private string PickUpItem(string parameter)
        {
            try
            {
                int itemID = Int32.Parse(parameter);
                foreach (Item item in ItemList)
                {
                    if(item.Id == itemID)
                    {
                        ThePlayer.AddItem(item);
                        ThePlayer.CurrentLocation.RemoveItem(item);
                    }
                }
            }
            catch (FormatException)
            {
                return "Could not parse item id";
            }
            return "Item Id not found";
        }

        private string GetLocationVerbose(string parameter)
        {
            try
            {
                int locationID = Int32.Parse(parameter);
                foreach (Location location in LocationList)
                {
                    if (location.Id == locationID)
                    {
                        return location.VerboseDescription;
                    }
                }
            }
            catch (FormatException)
            {
                return "Could not parse location id";
            }
            return "Location Id not found";
        }

        private string GetCharacterDescription(string parameter)
        {
            try
            {
                int charID = Int32.Parse(parameter);
                foreach (Character character in CharacterList)
                {
                    if (character.id == charID)
                    {
                        return character.CharacterDescription;
                    }
                }
            }
            catch (FormatException)
            {
                return "Could not parse character id";
            }
            return "Character Id not found";

        }

        private string GetItemDescription(string parameter)
        {
            try
            {
                int itemID = Int32.Parse(parameter);
                foreach (Item item in ItemList)
                {
                    if (item.Id == itemID)
                    {
                        return item.Description;
                    }
                }
            } catch (FormatException)
            {
                return "Could not parse item id";
            }
            return "Item Id not found";
        }
    }
}
 