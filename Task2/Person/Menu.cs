using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Person
{
    class Menu
    {
        String param = ConfigurationManager.AppSettings["Source"];
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
