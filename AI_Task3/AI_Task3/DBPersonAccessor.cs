using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace AI_Task3
{
    class DBPersonAccesor
    {
        SqlCeConnection connection =
            new SqlCeConnection(@"Data Source=C:\Users\Andrey_Isaev\documents\visual studio 2010\Projects\AI_Task3\AI_Task3\Database1.sdf");

        // Вывод всех значений в базе
        public void GetAll(Type t)
        {
            System.Attribute[] attrs = Attribute.GetCustomAttributes(t);
            connection.Open();
            foreach (Attribute attr in attrs)
            {
                if (attr is Attribut)
                {
                    Attribut att = (Attribut)attr;
                    string query = "SELECT * FROM " + att.TableName + "";
                    SqlCeCommand command = new SqlCeCommand(query, connection);
                    SqlCeDataReader read = command.ExecuteReader();
                    while (read.Read())
                    {
                        Console.WriteLine("{0}={1}",
                                            read[0].ToString(),
                                            read[1].ToString());
                    }
                }
            }
            connection.Close();
            Console.ReadKey();
        }

        //Поиск значения по имени
        public void GetByName(FieldInfo fieldInfo, Type t)
        {
            Console.WriteLine("Введите Имя для поиска");
            Attribute[] attrtable = Attribute.GetCustomAttributes(t);
            connection.Open();
            foreach (Attribute attrtab in attrtable)
            {
                if (attrtab is Attribut)
                {
                    Attribut attt = (Attribut)attrtab;
                    Attribute[] attrcolum1 = Attribute.GetCustomAttributes(fieldInfo);
                    foreach (Attribute attrcol1 in attrcolum1)
                    {
                        if (attrcol1 is Attribut)
                        {
                            Attribut attc1 = (Attribut)attrcol1;
                            String nm = Console.ReadLine();
                            string query = @"SELECT * FROM " + attt.TableName + " WHERE " + attc1.Colum1 + "='" + nm + "'";
                            SqlCeCommand command = new SqlCeCommand(query, connection);
                            SqlCeDataReader read = command.ExecuteReader();
                            while (read.Read())
                            {
                                Console.WriteLine("{0}={1}",
                                                    read[0].ToString(),
                                                    read[1].ToString());
                            }
                        }
                    }
                }
            }
            connection.Close();
            Console.ReadKey();
        }
        //Перезапись значения в базе
        public void Update(FieldInfo fieldInfo, Type t)
        {
            Console.WriteLine("Перезапись занчения");
            Attribute[] attrtable = Attribute.GetCustomAttributes(t);
            connection.Open();
            foreach (Attribute attrtab in attrtable)
            {
                if (attrtab is Attribut)
                {
                    Attribut attt = (Attribut)attrtab;
                    Attribute[] attrcolum1 = Attribute.GetCustomAttributes(fieldInfo);
                    foreach (Attribute attrcol1 in attrcolum1)
                    {
                        if (attrcol1 is Attribut)
                        {
                            Attribut attc1 = (Attribut)attrcol1;
                            Console.WriteLine("Введите Имя");
                            String nm = Console.ReadLine();
                            Console.WriteLine("Введите Значение");
                            String vl = Console.ReadLine();
                            string query = @"UPDATE " + attt.TableName + " SET Value = '" + vl + "' WHERE " + attc1.Colum1 + "='" + nm + "'";
                            SqlCeCommand command = new SqlCeCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            connection.Close();
            Console.ReadKey();
        }

        //Удаление значения из базы
        public void Delete(FieldInfo fieldInfo, Type t)
        {
            Console.WriteLine("Удаления записи");
            Attribute[] attrtable = Attribute.GetCustomAttributes(t);
            connection.Open();
            foreach (Attribute attrtab in attrtable)
            {
                if (attrtab is Attribut)
                {
                    Attribut attt = (Attribut)attrtab;
                    Attribute[] attrcolum1 = Attribute.GetCustomAttributes(fieldInfo);
                    foreach (Attribute attrcol1 in attrcolum1)
                    {
                        if (attrcol1 is Attribut)
                        {
                            Attribut attc1 = (Attribut)attrcol1;
                            Console.WriteLine("Введите Имя");
                            String nm = Console.ReadLine();
                            string query = @"DELETE FROM " + attt.TableName + " WHERE " + attc1.Colum1 + "='" + nm + "'";
                            SqlCeCommand command = new SqlCeCommand(query, connection);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            connection.Close();
            Console.ReadKey();
        }

        //Добавление нового значения в базу
        public void Add(FieldInfo fieldInfo, Type t, FieldInfo fieldInfo2)
        {
            Console.WriteLine("Добавление записи");
            Attribute[] attrtable = Attribute.GetCustomAttributes(t);
            connection.Open();
            foreach (Attribute attrtab in attrtable)
            {
                if (attrtab is Attribut)
                {
                    Attribut attt = (Attribut)attrtab;
                    Attribute[] attrcolum1 = Attribute.GetCustomAttributes(fieldInfo);
                    foreach (Attribute attrcol1 in attrcolum1)
                    {
                        if (attrcol1 is Attribut)
                        {
                            Attribut attc1 = (Attribut)attrcol1;
                            Attribute[] attrcolum2 = Attribute.GetCustomAttributes(fieldInfo2);
                            foreach (Attribute attrcol2 in attrcolum2)
                            {
                                if (attrcol1 is Attribut)
                                {
                                    Attribut attc2 = (Attribut)attrcol2;
                                    Console.WriteLine("Введите Имя");
                                    String nm = Console.ReadLine();
                                    Console.WriteLine("Введите Значение");
                                    String vl = Console.ReadLine();
                                    string query = @"INSERT INTO " + attt.TableName + " (" + attc1.Colum1 + ", " + attc2.Colum2 + ") VALUES ('" + nm + "', '" + vl + "')";
                                    SqlCeCommand command = new SqlCeCommand(query, connection);
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            connection.Close();
            Console.ReadKey();
        }
    }
}
