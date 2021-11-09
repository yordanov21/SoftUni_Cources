using System;
using System.Collections.Generic;
using System.Text;

namespace _03WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
