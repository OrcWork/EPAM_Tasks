using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestAuthorAttribute taa = new TestAuthorAttribute();
            taa.Test();
            Console.ReadKey();
        }
    }
}
