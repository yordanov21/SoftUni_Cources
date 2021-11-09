using System;
using System.Collections.Generic;
using System.Text;

namespace _1School
{
   public class Person
    {
        private string name;

        public Person(string name)
        {
           this.name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
