using System;
using System.Collections.Generic;
using System.Text;

namespace _1School
{
    class Subject
    {

        private string name;
        private int lab;
        private int exersice;

        public Subject(string name, int lab, int exersice)
        {
            this.Name = name;
            this.Lab = lab;
            this.Exersice = exersice;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Lab
        {
            get { return lab; }
            set { lab = value; }
        }

        public int Exersice
        {
            get { return exersice; }
            set { exersice = value; }
        }
    }
}
