using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using ExcelDataReader;
using System.IO;
using ExcelDataReader.Core;


namespace ExcelToInsert
{
    class Program
    {
        public static readonly string STRING_IDENTIFIER = "string";
        public static readonly string BOOL_IDENTIFIER = "bool";
        public static readonly string INT_IDENTIFIER = "int";
        public static readonly string SQL_INSERT_BEFORE = "INSERT INTO ";
        public static readonly string SQL_INSERT_MIDDLE = " VALUES( ";
        public static readonly string SQL_INSERT_END = " );\n";
        public static readonly List<string> LIST_OF_DIRECTIONS = new List<string> { "e (int)", "n (int)", "w (int)", "s (int)" };


        class Employee
        {
            string name { get; set; }
            int age { get; set; }

            public Employee(string name, int a)
            {
                this.name = name;
                this.age = a;
            }

            public string GetName()
            {
                return this.name;
            }

            public static int EmployeeCount = 0;
        }
        static void Main(string[] args)
        {
            
            string filePath = "../../TombstoneDb.xlsx";
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                var ListOfQueries = new List<string>();
                
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var ListOfHeaders = new List<string>();

                    do
                    {
                        bool isHeader = true;
                        //reads through each row
                        while (reader.Read())

                        { 
                            var values = "";
                            //reads through each columns
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (isHeader)
                                {

                                    ListOfHeaders.Add(reader.GetString(i));

                                }
                                else
                                {
                                    string value = "";
                                    if (ListOfHeaders.ElementAt(i).Contains(STRING_IDENTIFIER))
                                    {
                                       
                                        value = reader.GetString(i);
                                        value = value.Replace("'", "\"");
                                        value = "'" + value + "'";
                                    }
                                    
                                    else if (ListOfHeaders.ElementAt(i).Contains(BOOL_IDENTIFIER))
                                    {
                                        value = reader.GetBoolean(i).ToString();
                                    }
                                    else if (ListOfHeaders.ElementAt(i).Contains(INT_IDENTIFIER))
                                    {
                                        value = reader.GetDouble(i).ToString();
                                        if (value.Equals("-1") || LIST_OF_DIRECTIONS.Contains(ListOfHeaders.ElementAt(i)))
                                        {
                                            value = "null";
                                        }

                                    }
                                    values += value + ",";
                                }

                            }

                            isHeader = false;

                            if (!string.IsNullOrEmpty(values))
                            {
                                values = values.Substring(0, values.Length - 1);

                                string SqlInsert = SQL_INSERT_BEFORE + reader.Name + SQL_INSERT_MIDDLE + values + SQL_INSERT_END;

                                ListOfQueries.Add(SqlInsert);
                            }
                            
                        }
                        ListOfHeaders = new List<string>();

                        isHeader = true;
                        //moves to next sheet, until no more
                    } while (reader.NextResult());



                    //AddUpdates(filePath, "location", ListOfQueries);
                    File.AppendAllLines(@"../../TotalListOfInserts.txt", new List<string> { DateTime.Now.ToString() });
                    File.AppendAllLines(@"../../TotalListOfInserts.txt", ListOfQueries);
                    File.WriteAllLines(@"../../ListOfInserts.txt", ListOfQueries);
                    
                }
            }
        }

        private static void AddUpdates(string filePath, string tablename, List<string> ListOfQueries)
        {
            //"UPDATE location SET " loop of "header = num" if not -1 "WHERE" id = whatever ";"; 

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                var ListOfHeaders = new List<string>();

                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        bool isHeader = true;

                        if (reader.Name.Equals(tablename))
                        {
                            if(isHeader)
                            {
                                //ListOfHeaders.Add(reader.GetString(i))
                            }
                        }

                    } while (reader.NextResult());
                }
            }
        }
    }
}
