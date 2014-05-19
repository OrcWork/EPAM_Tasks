using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AI_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            String param = ConfigurationManager.AppSettings["Source"];
            if (param == "File")
            {
                Console.WriteLine("Работа с файлом");
            }
            if (param == "Memory")
            {
                Console.WriteLine("Работа с мемори");
            }
            if (param == "CustomORM")
            {
                Console.WriteLine("Работа с базой данных при помощи кастомного ORM");
            }
            if (param == "DataBase")
            {
                Console.WriteLine("Работа с базой данных");
            }
            Menu m = new Menu();
            m.MainMenu();
        }
    }
}
