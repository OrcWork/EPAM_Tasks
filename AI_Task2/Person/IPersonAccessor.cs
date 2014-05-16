using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person
{
    public interface IPersonAccessor
    {
        void GetAll();
        void GetByName();
        void Update();
        void Delete();
        void Add();
    }
}
