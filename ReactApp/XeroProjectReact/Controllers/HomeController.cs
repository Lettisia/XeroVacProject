using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

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
        public IEnumerable<string> TestDbPostCall( string data)
        {
            List<string> rows = new List<string>();


            return rows;
        }

        [HttpGet]
        public IEnumerable<string> TestDbCallDelete()
        {
            var connection = OpenDB();


            string[] tables = { "Item", "Player", "Location", "Inventory", "Character" };


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
    
    }
}
