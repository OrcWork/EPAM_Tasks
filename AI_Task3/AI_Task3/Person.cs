using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Task3
{
    [Attribut(TableName = "Person")]
    class Person
    {
        [Attribut(Colum1 = "Name")]
        public static string name;

        [Attribut(Colum2 = "Value")]
        public string value;
    }
}
