using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace AI_Task3
{
    class Menu
    {
        String param = ConfigurationManager.AppSettings["Source"];
        DBPersonAccesor dbpa = new DBPersonAccesor();
        public void MainMenu()
        {
            Console.WriteLine("1 - Отобразить все значения");
            Console.WriteLine("2 - Поиск значения по имени");
            Console.WriteLine("3 - Перезапись значения");
            Console.WriteLine("4 - Удаление значения");
            Console.WriteLine("5 - Добавление нового значения");
            Console.WriteLine("0 - Выход");

            String n = Console.ReadLine();
            switch (n)
            {
                case "0":
                    Console.WriteLine("Вы выбрали выход");
                    break;
                case "1":
                    Console.WriteLine("Отобразить все значения");
                    if (param == "File")
                    {
                        FilePersonAccessor fae = new FilePersonAccessor();
                        fae.parseFile();
                        fae.GetAll();
                    }
                    if (param == "Memory")
                    {
                        MemoryPersonAccessor mpa = new MemoryPersonAccessor();
                        mpa.GetAll();
                    }
                    if (param == "DataBase")
                    {
                        dbpa.GetAll(typeof(Person));
                    }
                    MainMenu();
                    break;

                case "2":
                    Console.WriteLine("Поиск значения по имени");
                    if (param == "File")
                    {
                        FilePersonAccessor fae = new FilePersonAccessor();
                        fae.parseFile();
                        fae.GetByName();
                    }
                    if (param == "Memory")
                    {
                        MemoryPersonAccessor mpa = new MemoryPersonAccessor();
                        mpa.GetByName();
                    }
                    if (param == "DataBase")
                    {
                        dbpa.GetByName(typeof(Person).GetField("name"), typeof(Person));
                    }
                    MainMenu();
                    break;

                case "3":
                    Console.WriteLine("Перезапись значения");
                    if (param == "File")
                    {
                        FilePersonAccessor fae = new FilePersonAccessor();
                        fae.parseFile();
                        fae.Update();
                    }
                    if (param == "Memory")
                    {
                        MemoryPersonAccessor mpa = new MemoryPersonAccessor();
                        mpa.Update();
                    }
                    if (param == "DataBase")
                    {
                        dbpa.Update(typeof(Person).GetField("name"), typeof(Person));
                    }
                    MainMenu();
                    break;

                case "4":
                    Console.WriteLine("Удаление значения");
                    if (param == "File")
                    {
                        FilePersonAccessor fae = new FilePersonAccessor();
                        fae.parseFile();
                        fae.Delete();
                    }
                    if (param == "Memory")
                    {
                        MemoryPersonAccessor mpa = new MemoryPersonAccessor();
                        mpa.Delete();
                    }
                    if (param == "DataBase")
                    {
                        dbpa.Delete(typeof(Person).GetField("name"), typeof(Person));
                    }
                    MainMenu();
                    break;

                case "5":
                    Console.WriteLine("Добавление нового значения");
                    if (param == "File")
                    {
                        FilePersonAccessor fae = new FilePersonAccessor();
                        fae.parseFile();
                        fae.Add();
                    }
                    if (param == "Memory")
                    {
                        MemoryPersonAccessor mpa = new MemoryPersonAccessor();
                        mpa.Add();
                    }
                    if (param == "DataBase")
                    {
                        dbpa.Add(typeof(Person).GetField("name"), typeof(Person), typeof(Person).GetField("value")); ;
                    }
                    MainMenu();
                    break;

                default:
                    Console.WriteLine("Выберите что-нибудь другое");
                    MainMenu();
                    break;
            }

        }
    }
}
