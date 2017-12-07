using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerWebAppTombstone.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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

                case "DROPITEM":
                    return DropItem(command.Parameter);
                case "WHERETOGO":
                    return CanGoHere(command.Parameter);
                case "GETINVENTORY":
                    return InventoryList();
                default:
                    return JsonConvert.SerializeObject(new { Message = "Invalid Command" });
            }
        }

        private string InventoryList()
        {
            List<Item> invent = ThePlayer.Inventory;

            if (invent.Count == 0)
                return JsonConvert.SerializeObject(new { Message = "Player inventory is empty" });
            else
                return JsonConvert.SerializeObject(invent);
        }

        private string CanGoHere(string parameter)
        {
            Location location = GetLocation(parameter);
            if (location == null)
            {
                return JsonConvert.SerializeObject(new { Message = "Unknown Location" });
            }

            List<Location> canGo = new List<Location>();
            if (location.East != null)
            {
                Location east = GetLocation(location.East.ToString());
                canGo.Add(east);
            }
            if (location.South != null)
            {
                Location south = GetLocation(location.South.ToString());
                canGo.Add(south);
            }
            if (location.West != null)
            {
                Location west = GetLocation(location.West.ToString());
                canGo.Add(west);
            }
            if (location.North != null)
            {
                Location north = GetLocation(location.North.ToString());
                canGo.Add(north);
            }
            return JsonConvert.SerializeObject(canGo);
        }

        private string DropItem(string parameter)
        {
            try
            {
                int itemID = Int32.Parse(parameter);
                foreach (Item item in ThePlayer.Inventory)
                {
                    if (item.Id == itemID)
                    {
                        ThePlayer.CurrentLocation.Additem(item);
                        ThePlayer.RemoveItem(item);
                        return JsonConvert.SerializeObject(new
                        {
                            Message = $"Item {item.Name} dropped in location {ThePlayer.CurrentLocation.Name}"
                        });
                    }
                }
            }
            catch (FormatException)
            {
                return JsonConvert.SerializeObject(new { Message = "Could not parse item id" });
            }
            return JsonConvert.SerializeObject(new { Message = "Item Id not found in this location" });
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
            catch (FormatException) {}
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
            
            return JsonConvert.SerializeObject(new { Message = "Location not found" });
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
                        return JsonConvert.SerializeObject(new
                        {
                            Message = $"Item {item.Name} picked up from from location {ThePlayer.CurrentLocation.Name}"
                        });
                    }
                }
            }
            catch (FormatException)
            {
                return JsonConvert.SerializeObject(new { Message = "Could not parse item id" });
            }
            return JsonConvert.SerializeObject(new { Message = "Item Id not found in this location" });
        }

        private string GetLocationVerbose(string parameter)
        {
            Location location = GetLocation(parameter);

            if (location != null)
            {
                return JsonConvert.SerializeObject(new { Message = location.VerboseDescription });
            }


            return JsonConvert.SerializeObject(new { Message = "Location Id not found" });
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
                        return JsonConvert.SerializeObject(new { Message = character.CharacterDescription });
                    }
                }
            }
            catch (FormatException)
            {
                return JsonConvert.SerializeObject(new { Message = "Could not parse character id" });
            }
            return JsonConvert.SerializeObject(new { Message = "Character Id not found" });

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
                        return JsonConvert.SerializeObject(new { Message = item.Description });
                    }
                }
            }
            catch (FormatException)
            {
                return JsonConvert.SerializeObject(new { Message = "Could not parse item id" });
            }
            return JsonConvert.SerializeObject(new { Message = "Item Id not found" });
        }
    }
}
