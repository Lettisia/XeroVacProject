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



        static void Test()
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

            //return rows;


        }
    }
}
