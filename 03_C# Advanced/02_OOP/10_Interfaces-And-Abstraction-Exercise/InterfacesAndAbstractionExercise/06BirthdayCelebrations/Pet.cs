using System;
using System.Collections.Generic;
using System.Text;

namespace _06BirthdayCelebrations
{
    class Pet : IBirtday
    {
        public Pet(string name, string date)
        {
            this.Name = name;
            this.Date = date;
        }

        public string Name { get; private set; }

        public string Date { get; private set; }
    }
}
