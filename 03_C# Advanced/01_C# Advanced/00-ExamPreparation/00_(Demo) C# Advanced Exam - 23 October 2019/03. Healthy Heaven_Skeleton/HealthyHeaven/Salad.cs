using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public string Name { get; set; }

        public int GetTotalCalories()
        {
            int calories = 0;
            foreach (var vegy in products)
            {
                calories += vegy.Calories;
            }
            return calories;
        }
    
        public int GetProductCount()
        {
            return products.Count;
        }
        public void Add(Vegetable product)
        {
            products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"* Salad {Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");

            foreach (var product in products)
            {
                sb.AppendLine($"{product}");
            }

            return sb.ToString().Trim();
        }
    }
}
