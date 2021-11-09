using System;
using System.Collections.Generic;
using System.Text;

namespace _06BirthdayCelebrations
{
    public class Citizen : IIndentifiable, IBirtday
    {
        public Citizen(string name, int age, string id, string date) 
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Date = date;

        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; private set; }

        public string Date { get; private set; }
    }
}
