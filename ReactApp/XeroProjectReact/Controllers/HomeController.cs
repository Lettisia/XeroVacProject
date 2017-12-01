using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using Newtonsoft.Json;
using XeroProjectReact.Models;
using XeroVacProjectConsole.Models;

namespace XeroProjectReact.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        private static NpgsqlConnection OpenDB()
        {
            var con = new NpgsqlConnection("Server=deathoftombstone.cfbtbnwur0gl.ap-southeast-2.rds.amazonaws.com;Port=5432;Database=DeathOfTombstone;User Id=Tombstone;Password=xerotomb");
            con.Open();
            return con;
        }

        //https://stackoverflow.com/questions/44925223/how-to-pass-data-to-controller-using-fetch-api-in-asp-net-core to send objects
        [HttpPost]
        public IEnumerable<string> TestDbPostCall(string data)
        {
            List<string> rows = new List<string>();


            return rows;
        }

        [HttpPost]
        public string DbAccessRow(string jsonStr)
        {
            Console.WriteLine(jsonStr);
            var cmd = JsonConvert.DeserializeObject<Command>(jsonStr);
            var connection = OpenDB();
            var command = new NpgsqlCommand(cmd.DBQuery(), connection);
            var reader = command.ExecuteReader();

            var response = "";
            if (reader.Read())
            {
                response = reader[0].ToString();
            }

            Console.WriteLine(response);
            InitialiseLocations();

            return response;
        }


        [HttpGet]
        public IEnumerable<string> TestDbCallDelete()
        {
            var connection = OpenDB();


            string[] tables = { "Item", "Player", "Location", "Character" };


            List<string> rows = new List<string>();
            var command = new NpgsqlCommand();
            //Npgsql.NpgsqlDataReader reader = new NpgsqlDataReader("");
            foreach (string s in tables)
            {
                int i = 0;
                command = new NpgsqlCommand("Select * from " + s + ";", connection);
                //command.Connection = connection;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rows.Add(reader[s + "id"].ToString());
                    i++;

                }
                Console.WriteLine(i);
                reader.Close();
            }

            command = new NpgsqlCommand("Select * from commands;", connection);
            var reader2 = command.ExecuteReader();

            while (reader2.Read())
            {
                rows.Add(reader2["commandname"].ToString());

            }
            reader2.Close();

            connection.Close();

            return rows;


        }

        public List<Location> InitialiseLocations()
        {
            var connection = OpenDB();
            var command = new NpgsqlCommand("SELECT * FROM location", connection);
            var reader = command.ExecuteReader();

            List<Location> locations = new List<Location>();
            
            while (reader.Read())
            {

                Location location = new Location();
                location.id = reader.GetInt32(0);
                location.name = reader.GetString(1);
                location.east = CheckNullIntegers(reader,2);
                location.west = CheckNullIntegers(reader, 3); 
                location.north = CheckNullIntegers(reader, 4);
                location.south = CheckNullIntegers(reader, 5);
                location.description = reader.GetString(6);
                location.verboseDescription = reader.GetString(7);
                locations.Add(location);

            }

            Console.WriteLine(locations);

            return locations;
        }

        public int? CheckNullIntegers(NpgsqlDataReader reader, int index)
        {
            if (reader.IsDBNull(index))
                return null;
            else
                return reader.GetInt32(index);
        }
    }
}
