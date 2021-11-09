using System;
using System.Collections.Generic;
using System.Text;

namespace _1School
{
    public class Student : Person
    {
        private int number;
        public Student(string name, int number)
            : base(name)
        {
            this.number = number;
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }




    }
}
