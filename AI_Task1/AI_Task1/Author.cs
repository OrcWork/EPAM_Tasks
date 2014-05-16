using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Task1
{

    class Author : System.Attribute
    {
        string name;
        public double version;

        public Author(string name)
        {
            this.name = name;

            // Default value.
            version = 1.0;
        }

        public string GetName()
        {
            return name;
        }
    }
}
