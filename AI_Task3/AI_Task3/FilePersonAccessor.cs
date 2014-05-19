using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AI_Task3
{
    public class FilePersonAccessor : IPersonAccessor
    {
        String filename = "TextFile1.txt";
        List<string> name = new List<string>();
        List<string> value = new List<string>();

        // Вывод всех значений в файле
        public void GetAll()
        {
            Console.WriteLine("Вывод всех имен и значений");
            try
            {
                StreamReader sr = new StreamReader(filename);
                String line = sr.ReadToEnd();
                Console.WriteLine(line);
                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        //Поиск значения по имени
        public void GetByName()
        {
            Console.WriteLine("Введите имя для поиска");
            String line;
            String nm = Console.ReadLine();
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] ss = line.Split('=');

                    if (ss[0] == nm)
                    {
                        Console.WriteLine(line);
                        break;
                    }
                }
                if (!name.Contains(nm))
                {
                    Console.WriteLine("Имя не найдено");
                }
                sr.Close();
            }
            Console.ReadKey();
        }


        //Перезапись значения в файле
        public void Update()
        {
            Console.WriteLine("Перезапись значения в файле");
            Console.WriteLine("Введите имя для поиска");
            String nm = Console.ReadLine();
            for (int i = 0; i < name.Count; i++)
            {
                if (name[i].ToString() == nm)
                {
                    Console.WriteLine("Введите новое значение");
                    String vl = Console.ReadLine();
                    value[i] = vl;
                }
            }
            if (!name.Contains(nm))
            {
                Console.WriteLine("Имя не найдено");
            }
            Rewrite();
            Console.ReadKey();
        }

        //Удаление Значения из файла
        public void Delete()
        {
            Console.WriteLine("Введите имя для удаления из файла");
            String nm = Console.ReadLine();
            if (!name.Contains(nm))
            {
                Console.WriteLine("Имя не найдено");
            }
            for (int i = 0; i < name.Count; i++)
            {
                if (name[i].ToString() == nm)
                {
                    name.RemoveAt(i);
                    value.RemoveAt(i);
                }
            }
            Rewrite();
            Console.ReadKey();
        }

        // Метод который парсит файл и записывает его в листы
        public void parseFile()
        {
            try
            {
                String line;
                using (StreamReader sr = new StreamReader(filename))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] ss = line.Split('=');
                        name.Add(ss[0]);
                        value.Add(ss[1]);
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        //Метод перезаписи файла
        public void Rewrite()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    for (int i = 0; i < name.Count; i++)
                    {
                        if (i != name.Count - 1)
                        {
                            sw.Write("{0}={1}\n", name[i], value[i]);
                        }
                        else
                        {
                            sw.Write("{0}={1}", name[i], value[i]);
                        }
                    }
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        //Добавление нового значения в файл
        public void Add()
        {
            Console.WriteLine("Введите имя для добавления в список");
            String nm = Console.ReadLine();
            Console.WriteLine("Введите значение для добавления в список");
            String vl = Console.ReadLine();
            name.Add(nm);
            value.Add(vl);
            Rewrite();
        }
    }
}
