using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Person
{
    class Person
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
            /*else
            {
                Console.WriteLine("Работа с мемори");
            }*/
            Menu m = new Menu();
            m.MainMenu();
        }
    }
}
