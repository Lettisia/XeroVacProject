using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using XeroVacProjectConsole.Models;
using XeroVacProjectConsole.Models.Items;

namespace XeroVacProjectConsole
{
    class Program
    {

        static NpgsqlConnection OpenDB()
        {
            var con = new NpgsqlConnection("Server=deathoftombstone.cfbtbnwur0gl.ap-southeast-2.rds.amazonaws.com;Port=5432;Database=DeathOfTombstone;User Id=Tombstone;Password=xerotomb");
            con.Open();
            return con;
        }



        static void Main(string[] args)
        {
            Item item = new Key();
            List<Item> items = new List<Item>();
            items.Add((Key)item);
            items.ElementAt(0);
            items.Add(new Key());

            Console.WriteLine(items.ElementAt(0) is Key);
            Console.WriteLine(items.ElementAt(1) is Key);

            List<Item> abc = new List<Item>(new Item[] {
                new Key(),
                new Door()
            });
            foreach(Item i in abc)
            {
                i.Interact(new Key());
            }

        }

        


        
    }
}
