using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Task1
{
    class TestAuthorAttribute
    {
        public void Test()
        {
            PrintAuthorInfo(typeof(FirstClass));
            PrintAuthorInfo(typeof(SecondClass));
        }

        private static void PrintAuthorInfo(System.Type t)
        {
            System.Console.WriteLine("Author information for {0}", t);

            // Using reflection.
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(t);  // Reflection.

            // Displaying output.
            foreach (System.Attribute attr in attrs)
            {
                if (attr is Author)
                {
                    Author a = (Author)attr;
                    System.Console.WriteLine("   {0}, version {1:f}", a.GetName(), a.version);
                }
            }
        }
    }
}
