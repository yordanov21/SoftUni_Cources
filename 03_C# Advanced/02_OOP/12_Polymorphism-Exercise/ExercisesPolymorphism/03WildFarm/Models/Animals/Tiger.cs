using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.Models.Animals
{
    public class Tiger : Mammal
    {
        public Tiger(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
