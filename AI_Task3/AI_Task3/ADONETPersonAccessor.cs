using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace AI_Task3
{
    class ADONETPersonAccessor
    {
        SqlCeConnection connection =
    new SqlCeConnection(@"Data Source=C:\Users\Andrey_Isaev\documents\visual studio 2010\Projects\AI_Task3\AI_Task3\Database1.sdf");
        public void GetAll()
        {
            string query = "SELECT * FROM Person";
            connection.Open();
            SqlCeCommand command = new SqlCeCommand(query, connection);
            SqlCeDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                Console.WriteLine("{0}={1}",
                                    read["NAME"].ToString(),
                                    read["VALUE"].ToString());
            }
            connection.Close();
            Console.ReadKey();
        }

        public void GetByName()
        {
            Console.WriteLine("Введите Имя для поиска");
            String nm = Console.ReadLine();
            string query = @"SELECT * FROM Person WHERE Name='" + nm + "'";
            connection.Open();
            SqlCeCommand command = new SqlCeCommand(query, connection);
            SqlCeDataReader read = command.ExecuteReader();

            while (read.Read())
            {
                Console.WriteLine("{0}={1}",
                                    read["NAME"].ToString(),
                                    read["VALUE"].ToString());
            }
            connection.Close();
            Console.ReadKey();
        }

        public void Update()
        {
            Console.WriteLine("Введите Имя");
            String nm = Console.ReadLine();
            Console.WriteLine("Введите Значение");
            String vl = Console.ReadLine();
            connection.Open();
            string query = @"UPDATE Person SET Value = '" + vl + "' WHERE Name='" + nm + "'";
            SqlCeCommand command = new SqlCeCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            Console.ReadKey();
        }

        public void Delete()
        {
            Console.WriteLine("Введите Имя для удаления");
            String nm = Console.ReadLine();
            connection.Open();
            string query = @"DELETE FROM Person WHERE Name='" + nm + "'";
            SqlCeCommand command = new SqlCeCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            Console.ReadKey();
        }

        public void Add()
        {
            Console.WriteLine("Введите Имя");
            String nm = Console.ReadLine();
            Console.WriteLine("Введите Значение");
            String vl = Console.ReadLine();
            connection.Open();
            string query = @"INSERT INTO Person (Name, Value) VALUES ('" + nm + "', '" + vl + "')";
            SqlCeCommand command = new SqlCeCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            Console.ReadKey();
        }
    }
}
