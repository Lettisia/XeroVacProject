using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static readonly List<string> LIST_OF_DIRECTION_COLUMNS = new List<string> { "e (int)", "n (int)", "w (int)", "s (int)" };
        public static readonly string ID_IDENTIFIER = "id (int)";

        public static readonly string SQL_UPDATE_BEFORE = "UPDATE ";
        public static readonly string SQL_UPDATE_MIDDLE = " SET ";
        public static readonly string SQL_UPDATE_END = " WHERE id = ";


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


        private static void AddInsertQueriesToList(string filePath, List<string> ListOfQueries)
        {
            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);


            do
            {
                var ListOfHeaders = ReadHeaderList(reader);

                while (reader.Read())
                {
                    ListOfQueries.Add(CreateInsertQueryFromRow(reader, ListOfHeaders));
                }
            } while (reader.NextResult());

            stream.Close();
            reader.Close();
        }

        static void Main(string[] args)
        {

            string filePath = "../../TombstoneDb.xlsx";
            var ListOfQueries = new List<string>();

            AddInsertQueriesToList(filePath, ListOfQueries);
            AddUpdateQueriesToList(filePath, "location", ListOfQueries);

            File.AppendAllLines(@"../../TotalListOfInserts.txt", new List<string> { DateTime.Now.ToString() });
            File.AppendAllLines(@"../../TotalListOfInserts.txt", ListOfQueries);
            File.WriteAllLines(@"../../ListOfInserts.txt", ListOfQueries);



        }



        private static string CreateInsertQueryFromRow(IExcelDataReader reader, List<string> ListOfHeaders)
        {
            var values = "";
            //reads through each columns
            for (int i = 0; i < reader.FieldCount; i++)
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
                    if (value.Equals("-1") || LIST_OF_DIRECTION_COLUMNS.Contains(ListOfHeaders.ElementAt(i)))
                    {
                        value = "null";
                    }

                }
                values += value + ",";


            }

            if (!string.IsNullOrEmpty(values))
            {
                values = values.Substring(0, values.Length - 1);

                string SqlInsert = SQL_INSERT_BEFORE + reader.Name + SQL_INSERT_MIDDLE + values + SQL_INSERT_END;

                return SqlInsert;
            }
            return "";

        }
    


        private static List<string> ReadHeaderList(IExcelDataReader reader)
        {
            reader.Read();
            var ListOfHeaders = new List<string>();
            for(int i = 0; i < reader.FieldCount; i ++)
            {
                ListOfHeaders.Add(reader.GetString(i));

            }
            return ListOfHeaders;
        }

        private static string CreateUpdateQueryFromRow(IExcelDataReader reader, List<string> ListOfHeaders)
        {
            string startOfQuery = SQL_UPDATE_BEFORE + reader.Name + SQL_UPDATE_MIDDLE;
            string columnsToUpdate = "";
            string endOfQuery = "";

            for (int i = 0; i < reader.FieldCount; i++)
            {

                string currentHeader = ListOfHeaders.ElementAt(i);
                if (currentHeader.Equals(ID_IDENTIFIER))
                {
                    endOfQuery = SQL_UPDATE_END + reader.GetDouble(i) + ";";
                }
                if (LIST_OF_DIRECTION_COLUMNS.Contains(currentHeader))
                {
                    int cellValue = (int)reader.GetDouble(i);
                    if (cellValue != -1)
                    {
                        string columnNameInDatabase = currentHeader.Split(' ')[0];
                        columnsToUpdate += columnNameInDatabase + " = " + cellValue + ", ";
                    }
                }
            }
            if (!string.IsNullOrEmpty(columnsToUpdate))
            {
                columnsToUpdate = columnsToUpdate.Substring(0, columnsToUpdate.Length - 1);
                var completeUpdateQuery = startOfQuery + columnsToUpdate + endOfQuery + "\n";
                return completeUpdateQuery;
            }
            return "";
        }

        private static void AddUpdateQueriesToList(string filePath, string tableName, List<string> ListOfQueries)
        {
            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            var ListOfHeaders = new List<string>();
            var reader = ExcelReaderFactory.CreateReader(stream);
            
            do
            {
                if (!reader.Name.Equals(tableName))
                {
                    continue;
                }

                ListOfHeaders = ReadHeaderList(reader);
            
                while (reader.Read())
                {
                    ListOfQueries.Add(CreateUpdateQueryFromRow(reader, ListOfHeaders));
                }
                
            } while (reader.NextResult());
            stream.Close();
            reader.Close();
        }
    }
}
