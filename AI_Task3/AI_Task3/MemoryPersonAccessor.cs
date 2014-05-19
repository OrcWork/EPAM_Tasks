using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AI_Task3
{
    public class MemoryPersonAccessor : IPersonAccessor
    {

        //Задаем список в котором будут храниться все значения
        static ArrayList name = new ArrayList() { "Name1", "Name2", "Name3", "Name4" };
        static ArrayList value = new ArrayList() { "Value1", "Value2", "Value3", "Value4" };

        // Вывод всех значений в списках
        public void GetAll()
        {
            Console.WriteLine("Ввывод всех имен и значений");
            for (int i = 0; i < name.Count; i++)
            {
                Console.WriteLine(name[i] + "=" + value[i]);
            }
            Console.ReadKey();
        }

        //Поиск значения по имени
        public void GetByName()
        {
            Console.WriteLine("Введите имя для поиска");
            String nm = Console.ReadLine();
            for (int i = 0; i < name.Count; i++)
            {
                if (name[i].ToString() == nm)
                {
                    Console.WriteLine(name[i] + "=" + value[i]);
                }
            }
            if (!name.Contains(nm))
            {
                Console.WriteLine("Имя не найдено");
            }
            Console.ReadKey();
        }

        //Перезапись значения в списке
        public void Update()
        {
            Console.WriteLine("Перезапись значения в списке");
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
        }

        //Удаление значения из списка
        public void Delete()
        {
            Console.WriteLine("Введите имя для удаления из списка");
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
        }

        //Добавление нового значения в список
        public void Add()
        {
            Console.WriteLine("Введите имя для добавления в список");
            String nm = Console.ReadLine();
            Console.WriteLine("Введите значение для добавления в список");
            String vl = Console.ReadLine();
            name.Add(nm);
            value.Add(vl);
        }
    }
}
