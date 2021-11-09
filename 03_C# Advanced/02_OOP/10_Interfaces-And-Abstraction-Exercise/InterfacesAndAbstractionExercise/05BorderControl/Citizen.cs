using System;
using System.Collections.Generic;
using System.Text;

namespace _05BorderControl
{
    public class Citizen : IIndentifiable
    {
        public Citizen(string name, int age, string id) 
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; private set; }

    }
}
