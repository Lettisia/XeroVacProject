using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerWebAppTombstone.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ServerWebAppTombstone.Models
{
    public sealed class World
    {
        public List<Item> ItemList { get; set; }

        public List<Character> CharacterList { get; set; }

        public List<Location> LocationList { get; set; }

        public Player ThePlayer { get; set; }

        private static World Instance = null;

        private World()
        {
            DbAccessController dbAccess = new DbAccessController();
            ItemList = dbAccess.InitialiseItems();
            CharacterList = dbAccess.InitialiseCharacter();
            LocationList = dbAccess.InitialiseLocations();
            ThePlayer = new Player();
            ThePlayer.CurrentLocation = LocationList.Find(location => location.IsStart == true);

            foreach (Item item in ItemList)
            {
                Location newLocation = LocationList.Find(location => location.Id == item.LocationId);
                if (newLocation != null)
                {
                    newLocation.Additem(item);
                }

            }
        } 

        public static World GetInstance()
        {
            if (Instance == null)
            {
                Instance = new World();
            }
            return Instance;
        }

        public string ExecuteCommand(Command command)
        {
            switch (command.Action)
            {
                case "CHARDESC":
                    return GetCharacterDescription(command.Parameter);
                case "TRAVEL":
                    return ChangeLocation(command.Parameter);
                case "PICKUP":
                    return PickUpItem(command.Parameter);
                case "LOCVERB":
                    return GetLocationVerbose(command.Parameter);
                case "EXAMINEITEM":
                    return GetItemDescription(command.Parameter);
                case "USEITEM":
                default:
                    return JsonConvert.SerializeObject("Invalid Command");
            }
        }

        public Location GetLocation(string parameter)
        {
            try
            {
                int locationID = Int32.Parse(parameter);
                foreach (Location location in LocationList)
                {
                    if (location.Id == locationID)
                    {
                        return location;
                    }
                }
            }
            catch (FormatException)
            {

            }
            return null;
        }

        private string ChangeLocation(string parameter)
        {
            Location location = GetLocation(parameter);


            if (location != null)
            {
                ThePlayer.CurrentLocation = location;
                return JsonConvert.SerializeObject(location);
            }

            string Message = "Location not found";
            return JsonConvert.SerializeObject(Message);
        }

        private string PickUpItem(string parameter)
        {
            try
            {
                int itemID = Int32.Parse(parameter);
                foreach (Item item in ThePlayer.CurrentLocation.ItemList)
                {
                    if (item.Id == itemID)
                    {
                        ThePlayer.AddItem(item);
                        ThePlayer.CurrentLocation.RemoveItem(item);
                        return JsonConvert.SerializeObject(
                            $"Item {item.Name} picked up from from location {ThePlayer.CurrentLocation.Name}");
                    }
                }
            }
            catch (FormatException)
            {
                return JsonConvert.SerializeObject("Could not parse item id");
            }
            return JsonConvert.SerializeObject("Item Id not found in this location");
        }

        private string GetLocationVerbose(string parameter)
        {
            Location location = GetLocation(parameter);

            if (location != null)
            {
                return JsonConvert.SerializeObject(location.VerboseDescription);
            }


            return JsonConvert.SerializeObject("Location Id not found");
        }

        private string GetCharacterDescription(string parameter)
        {
            try
            {
                int charID = Int32.Parse(parameter);
                foreach (Character character in CharacterList)
                {
                    if (character.Id == charID)
                    {
                        return JsonConvert.SerializeObject(character.CharacterDescription);
                    }
                }
            }
            catch (FormatException)
            {
                return JsonConvert.SerializeObject("Could not parse character id");
            }
            return JsonConvert.SerializeObject("Character Id not found");

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
                        return JsonConvert.SerializeObject(item.Description);
                    }
                }
            }
            catch (FormatException)
            {
                return JsonConvert.SerializeObject("Could not parse item id");
            }
            return JsonConvert.SerializeObject("Item Id not found");
        }
    }
}
