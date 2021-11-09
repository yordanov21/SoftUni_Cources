using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HealthyHeaven
{
     public class Restaurant
    {
        private List<Salad> salads;

        public Restaurant(string name)
        {
            this.Name = name;
            this.salads = new List<Salad>();

        }

        public string Name { get; set; }

        public void Add(Salad salad)
        {
            salads.Add(salad);
        }
        public bool Buy(string name)
        {
            foreach (var salad in this.salads)
            {
                if (salad.Name == name)
                {
                    this.salads.Remove(salad);
                    return true;
                }
            }
            return false;

        }
        public Salad GetHealthiestSalad()
        {
            return salads.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
        }

        public  string GenerateMenu()
        {

            StringBuilder menu = new StringBuilder();
            menu.AppendLine($"{Name} have {salads.Count} salads:");
            foreach (var salad in salads)
            {
                menu.AppendLine(salad.ToString());
            }

            return menu.ToString().TrimEnd();
        }

    }
}
