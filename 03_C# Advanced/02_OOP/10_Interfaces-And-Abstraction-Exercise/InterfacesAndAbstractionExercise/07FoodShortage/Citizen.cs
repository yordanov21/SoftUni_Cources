using System;
using System.Collections.Generic;
using System.Text;

namespace _07FoodShortage
{
    public class Citizen : IIndentifiable, IBirtday, IBuyer
    {
        public Citizen(string name, int age, string id, string date) 
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Date = date;
            this.Food = 0;//moje i bez tova ;

        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; private set; }

        public string Date { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
